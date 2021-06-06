namespace CodeRetreatBlazor.API.Hubs
{
    public class ChallengeConnection<TChallenge> where TChallenge : class
    {
        public string ConnectionId { get; set; }
        public int ChallengeId { get; set; }
        public int TeamId { get; set; }
        public ChallengeWrapper<TChallenge> ChallengeWrapper { get; set; }

        public ChallengeConnection(string connectionId, int challengeId, int teamId)
        {
            ConnectionId = connectionId;
            ChallengeId = challengeId;
            TeamId = teamId;
        }
    }
}
