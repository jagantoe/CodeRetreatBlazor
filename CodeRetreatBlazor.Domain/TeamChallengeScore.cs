using System;

namespace CodeRetreatBlazor.Domain
{
    public class TeamChallengeScore
    {
        public int Id { get; set; }
        public int ChallengeId { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Attempts { get; set; }
        public bool Completed { get; set; }

        public TeamChallengeScore()
        {

        }
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
            Completed = true;
        }
    }
}
