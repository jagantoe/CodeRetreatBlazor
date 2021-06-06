using System.Collections.Generic;

namespace CodeRetreatBlazor.Domain
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TeamChallengeScore> Scores { get; set; } = new List<TeamChallengeScore>();
    }
}
