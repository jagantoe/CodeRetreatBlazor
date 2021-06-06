using CodeRetreatBlazor.Service.InfiniteDoors;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CodeRetreatBlazor.API.Hubs.InfiniteDoorsHub
{
    public class InfiniteDoorsHub : ChallengeHub<InfinitePrimeDoorChallenge>
    {
        private InfiniteDoorsDTO Level => new InfiniteDoorsDTO(Challenge);
        public InfiniteDoorsHub(ChallengeManager<InfinitePrimeDoorChallenge> challengeManager): base(1, challengeManager)
        {

        }

        public async Task OpenDoor(int door)
        {
            Challenge.OpenDoor(door);

            Score.IncrementAttempt();
            if (Challenge.Completed)
            {
                Score.CompleteChallenge();
            }
            await Clients.Caller.SendAsync("Doors", Level);
        }

        public override async Task StartChallengeAsync()
        {
            ChallengeWrapper.SetChallenge(new InfinitePrimeDoorChallenge());
            await Clients.Caller.SendAsync("Doors", Level);
        }
    }
}
