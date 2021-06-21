using CodeRetreatBlazor.Service.Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CodeRetreatBlazor.Service.RoundRobin
{
    public class RoundRobinLevel
    {
        public int Level { get; set; }
        public DateTime Time { get; set; }
        public List<int> Keys = new List<int>();

        public RoundRobinLevel(int level)
        {
            Level = level;
            Time = DateTime.Now;
            GenerateKeys();
        }

        private void GenerateKeys()
        {
            var amountOfKeys = Math.Pow(2, Level + 2); // Level 1: 8 Keys | Level 2: 16 keys | Level 3: 32 keys | Level 4: 63 keys | Level 5: 128 keys
            for (int i = 0; i < amountOfKeys; i++)
            {
                Keys.Add(NumberGenerator.GetPrimeNumber());
            };
        }

        public bool CheckResult(int[][][] supersets)
        {
            var sets = supersets.SelectMany(s => s).ToArray();
            var keys = sets.SelectMany(s => s).ToArray();

            if (CheckTotalAmountOfCombinations() && CheckAllKeysThere() && CheckAmountOfCombinations() && CheckDuplicateCombinations())
            {
                return true;
            }
            return false;

            bool CheckAllKeysThere()
            {
                return Keys.OrderBy(k => k).SequenceEqual(keys.Distinct().OrderBy(k => k));
            }
            bool CheckAmountOfCombinations()
            {
                var keyscount = keys.Count();
                var keysCounter = new ConcurrentDictionary<int, int>();
                var expectedResult = Keys.Count - 1;
                for (int i = 0; i < keyscount; i++)
                {
                    keysCounter.AddOrUpdate(keys[i], 1, (key, oldvalue) => { return oldvalue + 1; });
                }
                foreach (var (key, value) in keysCounter)
                {
                    if (value != expectedResult)
                    {
                        return false;
                    }
                }
                return true;
            }
            bool CheckTotalAmountOfCombinations()
            {
                var expectedResult = (Keys.Count * (Keys.Count - 1)) / 2;
                return sets.Count() == expectedResult;
            }
            bool CheckDuplicateCombinations()
            {
                var expectedResult = (Keys.Count * (Keys.Count - 1)) / 2;
                return sets.Distinct(new ArrayComparer()).Count() == expectedResult;
            }
        }
    }

    public class ArrayComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            var x1 = x[0];
            var x2 = x[1];
            var y1 = y[0];
            var y2 = y[1];
            if ((x1 == y1 && x2 == y2) || (x1 == y2 && x2 == y1))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] int[] obj)
        {
            return obj.GetHashCode();
        }
    }
}
