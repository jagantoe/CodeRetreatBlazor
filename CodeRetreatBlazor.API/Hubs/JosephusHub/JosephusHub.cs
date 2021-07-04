using CodeRetreatBlazor.Service.Josephus;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CodeRetreatBlazor.API.Hubs.JosephusHub
{
    public class JosephusHub : ChallengeHub<JosephusChallenge>
    {
        private JosephusDTO Level => new JosephusDTO(Challenge);
        public JosephusHub(ChallengeManager<JosephusChallenge> challengeManager) : base(3, challengeManager)
        {

        }

        public async Task LastPirate(int pirate)
        {
            if (!Challenge.Completed)
            {
                Challenge.CheckPirate(pirate);
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

            await Clients.Caller.SendAsync("Pirates", Level);
        }

        public override async Task StartChallengeAsync()
        {
            if (Challenge == null)
            {
                ChallengeWrapper.SetChallenge(new JosephusChallenge());
            }
            if (Score.Completed)
            {
                Challenge.Complete();
                DisposeData();
                Context.Abort();
                return;
            }
            await Clients.Caller.SendAsync("Pirates", Level);
        }
    }
}
