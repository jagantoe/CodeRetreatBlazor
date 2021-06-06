using System.Collections.Generic;

namespace CodeRetreatBlazor.Domain
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<TeamChallengeScore> Scores { get; set; } = new List<TeamChallengeScore>();
    }
}
