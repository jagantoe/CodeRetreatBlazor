using CodeRetreatBlazor.Domain;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CodeRetreatBlazor.API.Hubs
{
    public abstract class ChallengeHub<TChallenge> : Hub where TChallenge : class
    {
        private readonly ChallengeManager<TChallenge> _challengeManager;
        private readonly int ChallengeId;

        protected ChallengeWrapper<TChallenge> challengeWrapper;
        protected ChallengeWrapper<TChallenge> ChallengeWrapper
        {
            get
            {
                if (challengeWrapper == null)
                {
                    challengeWrapper = _challengeManager.GetChallengeWrapper(Context.ConnectionId);
                }
                return challengeWrapper;
            }
        }
        public TChallenge Challenge
        {
            get
            {
                return ChallengeWrapper.Challenge;
            }
        }
        public TeamChallengeScore Score
        {
            get
            {
                return ChallengeWrapper.TeamChallengeScore;
            }
        }

        public ChallengeHub(int challengeId, ChallengeManager<TChallenge> challengeManager)
        {
            this.ChallengeId = challengeId;
            _challengeManager = challengeManager;
        }

        public ChallengeHub(ChallengeManager<TChallenge> challengeManager)
        {
            _challengeManager = challengeManager;
        }

        public async Task StartChallenge(string name, string password)
        {
            var success = await _challengeManager.AddConnection(name, password, Context.ConnectionId, ChallengeId);
            if (success)
            {
                await StartChallengeAsync();
            }
            else
            {
                Context.Abort();

            }
        }

        public abstract Task StartChallengeAsync();
    }
}
