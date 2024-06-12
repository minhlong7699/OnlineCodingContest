using Microsoft.EntityFrameworkCore;
using CodingContest.Domain.Models;
using System.Reflection;

namespace CodingContest.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Problem> Problems => Set<Problem>();
        public DbSet<Contest> Contests => Set<Contest>();
        public DbSet<ContestLeaderboard> ContestLeaderboards => Set<ContestLeaderboard>();
        public DbSet<ContestProblem> ContestProblems => Set<ContestProblem>();
        public DbSet<DailyProblem> DailyProblems => Set<DailyProblem>();
        public DbSet<Language> Languages => Set<Language>();
        public DbSet<ProblemLanguage> ProblemLanguages => Set<ProblemLanguage>();
        public DbSet<ProblemTag> ProblemTags => Set<ProblemTag>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Submission> Submissions => Set<Submission>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<TestCase> TestCases => Set<TestCase>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserLog> UserLogs => Set<UserLog>();
        public DbSet<UserPasswordReset> UserPasswordResets => Set<UserPasswordReset>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<UserSolvedProblem> UserSolvedProblems => Set<UserSolvedProblem>();
        public DbSet<UserToken> UserTokens => Set<UserToken>();
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
