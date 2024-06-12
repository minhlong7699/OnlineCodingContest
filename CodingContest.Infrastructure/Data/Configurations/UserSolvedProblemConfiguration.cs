using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class UserSolvedProblemConfiguration : IEntityTypeConfiguration<UserSolvedProblem>
    {
        public void Configure(EntityTypeBuilder<UserSolvedProblem> builder)
        {
            builder.HasKey(usp => usp.Id);
            builder.Property(usp => usp.UserId).IsRequired();
            builder.Property(usp => usp.ProblemId).IsRequired();
            builder.Property(usp => usp.SolvedDatetime).IsRequired();
            builder.Property(usp => usp.Status).IsRequired().HasMaxLength(100);

            builder.HasOne(usp => usp.User)
                   .WithMany(u => u.UserSolvedProblems)
                   .HasForeignKey(usp => usp.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(usp => usp.Problem)
                   .WithMany()
                   .HasForeignKey(usp => usp.ProblemId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
