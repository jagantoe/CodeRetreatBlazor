using CodeRetreatBlazor.Service.InfiniteDoors;
using System;
using System.Collections.Generic;

namespace CodeRetreatBlazor.API.Hubs.InfiniteDoorsHub
{
    public class InfiniteDoorsDTO
    {
        public int Level { get; set; }
        public DateTime Time { get; set; }
        public List<int> Doors { get; set; }
        public InfiniteDoorsDTO(InfinitePrimeDoorChallenge challenge)
        {
            Level = challenge.CurrentLevel;
            Time = challenge.InfinitePrimeDoorLevel.Time;
            Doors = challenge.InfinitePrimeDoorLevel.Doors;
        }
    }
}
