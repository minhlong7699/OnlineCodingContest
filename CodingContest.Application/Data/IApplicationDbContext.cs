using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using CodingContest.Domain.Models;
using System.Collections.Generic;

public interface IApplicationDbContext
{
    DbSet<Problem> Problems { get; }
    DbSet<Contest> Contests { get; }
    DbSet<ContestLeaderboard> ContestLeaderboards { get; }
    DbSet<ContestProblem> ContestProblems { get; }
    DbSet<DailyProblem> DailyProblems { get; }
    DbSet<Language> Languages { get; }
    DbSet<ProblemLanguage> ProblemLanguages { get; }
    DbSet<ProblemTag> ProblemTags { get; }
    DbSet<Role> Roles { get; }
    DbSet<Submission> Submissions { get; }
    DbSet<Tag> Tags { get; }
    DbSet<TestCase> TestCases { get; }
    DbSet<User> Users { get; }
    DbSet<UserLog> UserLogs { get; }
    DbSet<UserPasswordReset> UserPasswordResets { get; }
    DbSet<UserRole> UserRoles { get; }
    DbSet<UserSolvedProblem> UserSolvedProblems { get; }
    DbSet<UserToken> UserTokens { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
