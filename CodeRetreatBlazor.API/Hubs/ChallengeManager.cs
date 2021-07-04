using CodeRetreatBlazor.DataAccess;
using CodeRetreatBlazor.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeRetreatBlazor.API.Hubs
{
    public class ChallengeManager<TChallenge> where TChallenge : class
    {
        private List<ChallengeConnection<TChallenge>> Connections = new();
        private List<ChallengeWrapper<TChallenge>> ChallengeWrappers = new();

        public async Task<bool> AddConnection(string name, string password, string connectionId, int challengeId)
        {
            Team team;
            using (var context = new ChallengeContext())
            {
                team = await context.Teams.FirstOrDefaultAsync(t => t.Name == name);
                if (team == null || (team?.Name != name || team?.Password != password))
                {
                    return false;
                }
            }
            var connection = new ChallengeConnection<TChallenge>(connectionId, challengeId, team.Id);
            Connections.Add(connection);
            var challengeWrapper = ChallengeWrappers.SingleOrDefault(c => c.ChallengeId == challengeId && c.TeamId == team.Id);
            if (challengeWrapper == null)
            {
                challengeWrapper = new ChallengeWrapper<TChallenge>(challengeId, team.Id);
                await challengeWrapper.LoadTeamChallengeScore();
                ChallengeWrappers.Add(challengeWrapper);
            }
            connection.ChallengeWrapper = challengeWrapper;
            return true;
        }

        public ChallengeWrapper<TChallenge> GetChallengeWrapper(string connectionId)
        {
            var connection = Connections.SingleOrDefault(c => c.ConnectionId == connectionId);
            return connection.ChallengeWrapper;
        }

        public void RemoveConnection(string connectionId)
        {
            Connections.RemoveAll(c => c.ConnectionId == connectionId);
        }

        public void RemoveChallengeAndConnections(ChallengeWrapper<TChallenge> ChallengeWrapper)
        {
            Connections.RemoveAll(c => c.ChallengeId == ChallengeWrapper.ChallengeId && c.TeamId == ChallengeWrapper.TeamId);
            ChallengeWrappers.Remove(ChallengeWrapper);
            ChallengeWrapper.Dispose();
        }
    }
}
