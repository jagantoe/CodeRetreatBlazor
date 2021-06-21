using CodeRetreatBlazor.DataAccess;
using CodeRetreatBlazor.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeRetreatBlazor.API.Hubs
{
    public class ChallengeWrapper<TChallenge> where TChallenge : class
    {
        public int ChallengeId;
        public int TeamId;
        private ChallengeContext ChallengeContext;
        public TeamChallengeScore TeamChallengeScore;
        public TChallenge Challenge;
        public ChallengeWrapper(int challengeId, int teamId)
        {
            ChallengeId = challengeId;
            TeamId = teamId;
            ChallengeContext = new ChallengeContext();
        }

        public async Task LoadTeamChallengeScore()
        {
            TeamChallengeScore = await ChallengeContext.TeamChallengeScores.FirstOrDefaultAsync(l => l.ChallengeId == ChallengeId && l.TeamId == TeamId);
            if (TeamChallengeScore == null)
            {
                TeamChallengeScore = CreateNewTeamChallengeScore();
                Save();
            }
        }

        private TeamChallengeScore CreateNewTeamChallengeScore()
        {
            return new TeamChallengeScore(ChallengeId, TeamId);
        }

        public void SetChallenge(TChallenge challenge)
        {
            Challenge = challenge;
        }

        public void Save()
        {
            ChallengeContext.Update(TeamChallengeScore);
            ChallengeContext.SaveChanges();
        }

        public void Dispose()
        {
            TeamId = 0;
            ChallengeContext.Dispose();
            TeamChallengeScore = null;
            Challenge = null;
        }
    }
}
