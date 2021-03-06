using CodeRetreatBlazor.Service.RoundRobin;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CodeRetreatBlazor.API.Hubs.RoundRobinHub
{
    public class RoundRobinHub : ChallengeHub<RoundRobinChallenge>
    {
        private RoundRobinDTO Level => new RoundRobinDTO(Challenge);
        public RoundRobinHub(ChallengeManager<RoundRobinChallenge> challengeManager) : base(2, challengeManager)
        {
        }

        public async Task OpenDoors(int[][][] combinations)
        {
            if (!Challenge.Completed)
            {
                Challenge.OpenDoor(combinations);
                Score.IncrementAttempt();
                if (Challenge.Completed)
                {
                    Score.CompleteChallenge();
                    Save();
                    DisposeData();
                    Context.Abort();
                    return;
                }
                Save();
            }
            await Clients.Caller.SendAsync("Keys", Level);
        }

        public override async Task StartChallengeAsync()
        {
            if (Challenge == null)
            {
                ChallengeWrapper.SetChallenge(new RoundRobinChallenge());
            }
            if (Score.Completed)
            {
                Challenge.Complete();
                DisposeData();
                Context.Abort();
                return;
            }
            await Clients.Caller.SendAsync("Keys", Level);
        }
    }
}
