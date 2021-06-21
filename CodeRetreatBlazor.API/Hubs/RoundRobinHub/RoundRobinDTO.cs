using CodeRetreatBlazor.Service.RoundRobin;
using System;
using System.Collections.Generic;

namespace CodeRetreatBlazor.API.Hubs.RoundRobinHub
{
    public class RoundRobinDTO
    {
        public int Level { get; set; }
        public DateTime Time { get; set; }
        public List<int> Keys { get; set; }
        public RoundRobinDTO(RoundRobinChallenge challenge)
        {
            Level = challenge.CurrentLevel;
            Time = challenge.RoundRobinLevel.Time;
            Keys = challenge.RoundRobinLevel.Keys;
        }
    }
}
