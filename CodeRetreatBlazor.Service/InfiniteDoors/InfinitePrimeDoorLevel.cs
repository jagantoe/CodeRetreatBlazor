using System;
using System.Collections.Generic;

namespace CodeRetreatBlazor.Service.InfiniteDoors
{
    public class InfinitePrimeDoorLevel
    {
        public int Level { get; set; }
        public DateTime Time { get; set; }
        public int CorrectDoor { get; set; }
        public List<int> Doors = new List<int>();
        private Random Random = new Random();
        public InfinitePrimeDoorLevel(int level)
        {
            Level = level;
            Time = DateTime.Now;
            GenerateDoors();
        }

        private void GenerateDoors()
        {
            if (Time.Second % 2 == 0)
            {
                AddCorrectDoor(NumberGenerator.GetPrimeNumber);
                AddWrongDoor(NumberGenerator.GetNonPrimeNumber);
            }
            else
            {
                AddCorrectDoor(NumberGenerator.GetNonPrimeNumber);
                AddWrongDoor(NumberGenerator.GetPrimeNumber);
            }
            RandomizeOrder();
        }

        private void AddCorrectDoor(Func<int> func)
        {
            CorrectDoor = func();
            Doors.Add(CorrectDoor);
        }
        private void AddWrongDoor(Func<int> func)
        {
            var amountOfDoors = 2 + (int)Math.Floor(Level / 10.0);
            for (int i = 0; i < amountOfDoors; i++)
            {
                Doors.Add(func());
            }
        }

        private void RandomizeOrder()
        {
            for (int i = Doors.Count -1; i > 0; i--)
            {
                var index = Random.Next(0, i);
                var temp = Doors[i];
                Doors[i] = Doors[index];
                Doors[index] = temp;

            }
        }

        public bool ValidOption(int door)
        {
            return Doors.Exists(d => d == door);
        }

        public bool CheckResult(int door)
        {
            return door == CorrectDoor;
        }
    }
}
