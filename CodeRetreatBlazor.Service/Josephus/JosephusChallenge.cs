namespace CodeRetreatBlazor.Service.Josephus
{
    public class JosephusChallenge
    {
        public bool Completed { get; set; }
        public int CurrentLevel { get; set; }
        public JosephusLevel JosephusLevel { get; set; }

        public JosephusChallenge()
        {
            Reset();
        }

        public void CheckPirate(int pirate)
        {
            if (!Completed)
            {
                if (JosephusLevel.CheckResult(pirate))
                {
                    if (CurrentLevel == 10)
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
            JosephusLevel = new JosephusLevel(CurrentLevel);
        }

        private void NextLevel()
        {
            CurrentLevel++;
            JosephusLevel = new JosephusLevel(CurrentLevel);
        }

        public void Complete()
        {
            Completed = true;
            JosephusLevel.Pirates.Clear();
        }
    }
}
