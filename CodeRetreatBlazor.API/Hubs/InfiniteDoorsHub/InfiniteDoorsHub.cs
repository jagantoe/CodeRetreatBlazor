using CodeRetreatBlazor.Service.InfiniteDoors;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CodeRetreatBlazor.API.Hubs.InfiniteDoorsHub
{
    public class InfiniteDoorsHub : ChallengeHub<InfinitePrimeDoorChallenge>
    {
        private InfiniteDoorsDTO Level => new InfiniteDoorsDTO(Challenge);
        public InfiniteDoorsHub(ChallengeManager<InfinitePrimeDoorChallenge> challengeManager) : base(1, challengeManager)
        {

        }

        public async Task OpenDoor(int door)
        {
            if (!Challenge.Completed)
            {
                Challenge.OpenDoor(door);
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

            await Clients.Caller.SendAsync("Doors", Level);
        }

        public override async Task StartChallengeAsync()
        {
            if (Challenge == null)
            {
                ChallengeWrapper.SetChallenge(new InfinitePrimeDoorChallenge());
            }
            if (Score.Completed)
            {
                Challenge.Complete();
                DisposeData();
                Context.Abort();
                return;
            }
            await Clients.Caller.SendAsync("Doors", Level);
        }
    }
}
