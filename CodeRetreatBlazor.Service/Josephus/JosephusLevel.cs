using CodeRetreatBlazor.Service.Shared;
using System;
using System.Collections.Generic;

namespace CodeRetreatBlazor.Service.Josephus
{
    public class JosephusLevel
    {
        public int Level { get; set; }
        public DateTime Time { get; set; }
        public int LastPirate { get; set; }
        public List<int> Pirates = new List<int>();

        public JosephusLevel(int level)
        {
            Level = level;
            Time = DateTime.Now;
            GeneratePirates();
        }

        private void GeneratePirates()
        {
            var powerOf2 = Level + 2;
            var amountOfPirates = (int)Math.Pow(2, powerOf2);
            var extra = new Random().Next(1, amountOfPirates);
            amountOfPirates += extra;
            for (int i = 0; i < amountOfPirates; i++)
            {
                Pirates.Add(NumberGenerator.GetPrimeNumber());
            }
            LastPirate = GetLastPirate(extra);
        }

        private int GetLastPirate(int extra)
        {
            var position = (extra * 2) + 1;
            return Pirates[position - 1];
        }

        public bool CheckResult(int pirate)
        {
            return pirate == LastPirate;
        }
    }
}
