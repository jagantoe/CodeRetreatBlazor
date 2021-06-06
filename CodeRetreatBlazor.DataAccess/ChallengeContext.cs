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
        //public ChallengeContext([NotNullAttribute] DbContextOptions options) : base(options)
        //{
        //}

        //Run Migrations
        //dotnet ef migrations add Initial --output-dir ../CodeRetreatBlazor.DataAccess/Migrations --startup-project ..\CodeRetreatBlazor
        //dotnet ef database update --startup-project ..\CodeRetreatBlazor\
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MSI;Database=Example;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;")
                          .LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
