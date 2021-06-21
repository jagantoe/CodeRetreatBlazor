namespace CodeRetreatBlazor.Service.RoundRobin
{
    public class RoundRobinChallenge
    {
        public bool Completed { get; set; }
        public int CurrentLevel { get; set; }
        public RoundRobinLevel RoundRobinLevel { get; set; }

        public RoundRobinChallenge()
        {
            Reset();
        }

        public void OpenDoor(int[][][] result)
        {
            if (!Completed)
            {
                if (RoundRobinLevel.CheckResult(result))
                {
                    if (CurrentLevel == 5)
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
            RoundRobinLevel = new RoundRobinLevel(CurrentLevel);
        }

        private void NextLevel()
        {
            CurrentLevel++;
            RoundRobinLevel = new RoundRobinLevel(CurrentLevel);
        }

        public void Complete()
        {
            Completed = true;
            RoundRobinLevel.Keys.Clear();
        }
    }
}
