using System;

namespace CodeRetreatBlazor.Domain
{
    public class TeamChallengeScore
    {
        public int Id { get; private set; }
        public int ChallengeId { get; private set; }
        public int TeamId { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public int Attempts { get; private set; }
        public bool Completed { get; private set; }

        public TeamChallengeScore(int challengeId, int teamId)
        {
            ChallengeId = challengeId;
            TeamId = teamId;
            StartTime = DateTime.UtcNow;
        }

        public void IncrementAttempt()
        {
            Attempts++;
        }

        public void CompleteChallenge()
        {
            EndTime = DateTime.UtcNow;
        }
    }
}
