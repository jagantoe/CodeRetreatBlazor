using CodeRetreatBlazor.Service.Josephus;
using System;
using System.Collections.Generic;

namespace CodeRetreatBlazor.API.Hubs.JosephusHub
{
    public class JosephusDTO
    {
        public int Level { get; set; }
        public DateTime Time { get; set; }
        public List<int> Pirates { get; set; }
        public JosephusDTO(JosephusChallenge challenge)
        {
            Level = challenge.CurrentLevel;
            Time = challenge.JosephusLevel.Time;
            Pirates = challenge.JosephusLevel.Pirates;
        }
    }
}
