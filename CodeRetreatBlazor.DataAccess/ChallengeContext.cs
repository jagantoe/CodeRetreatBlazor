using CodeRetreatBlazor.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CodeRetreatBlazor.DataAccess
{
    public class ChallengeContext: DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<TeamChallengeScore> TeamChallengeScores { get; set; }
        public ChallengeContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Connectionstring").LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
