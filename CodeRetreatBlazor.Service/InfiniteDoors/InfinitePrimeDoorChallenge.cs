namespace CodeRetreatBlazor.Service.InfiniteDoors
{
    public class InfinitePrimeDoorChallenge
    {
        public bool Completed { get; set; }
        public int CurrentLevel { get; set; }
        public InfinitePrimeDoorLevel InfinitePrimeDoorLevel { get; set; }

        public InfinitePrimeDoorChallenge()
        {
            Reset();
        }

        public void OpenDoor(int door)
        {
            if (!Completed && InfinitePrimeDoorLevel.ValidOption(door))
            {
                if (InfinitePrimeDoorLevel.CheckResult(door))
                {
                    if (CurrentLevel == 100)
                    {
                        Complete();
                    }
                    else
                    {
                        NextLevel();
                    }
                }
                else
                {
                    Reset();
                }
            }
        }

        private void Reset()
        {
            CurrentLevel = 1;
            InfinitePrimeDoorLevel = new InfinitePrimeDoorLevel(CurrentLevel);
        }

        private void NextLevel()
        {
            CurrentLevel++;
            InfinitePrimeDoorLevel = new InfinitePrimeDoorLevel(CurrentLevel);
        }

        private void Complete()
        {
            Completed = true;
        }
    }
}
