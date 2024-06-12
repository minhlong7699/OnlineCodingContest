using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;
using CodingContest.Domain.ValueObjects;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
    {
        public void Configure(EntityTypeBuilder<Problem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                   .HasConversion(
                       v => v.Value,
                       v => Title.Of(v))
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.Description)
                   .HasConversion(
                       v => v.Value,
                       v => Description.Of(v))
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(p => p.Difficulty).IsRequired();
            builder.Property(p => p.Constraints);
            builder.Property(p => p.Hints);
            builder.Property(p => p.Author)
                   .HasConversion(
                       v => v.Value,
                       v => Author.Of(v))
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.LastModifiedDate).IsRequired();
            builder.Property(p => p.TimeLimit)
                   .HasConversion(
                       v => v.Value,
                       v => TimeLimit.Of(v))
                   .IsRequired();

            builder.Property(p => p.MemoryLimit)
                   .HasConversion(
                       v => v.Value,
                       v => MemoryLimit.Of(v))
                   .IsRequired();

            builder.Property(p => p.Solution);
            builder.Property(p => p.TotalSubmissions).IsRequired();
            builder.Property(p => p.AcceptedSubmissions).IsRequired();
            builder.Property(p => p.TestCaseCount).IsRequired();
            builder.Property(p => p.IsAdminCreated).IsRequired();
            builder.Property(p => p.DescriptionImageUrl).IsRequired();

            builder.HasMany(p => p.TestCases)
                   .WithOne(tc => tc.Problem)
                   .HasForeignKey(tc => tc.ProblemId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.ContestProblems)
                   .WithOne(cp => cp.Problem)
                   .HasForeignKey(cp => cp.ProblemId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.DailyProblems)
                   .WithOne(dp => dp.Problem)
                   .HasForeignKey(dp => dp.ProblemId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Submissions)
                   .WithOne(s => s.Problem)
                   .HasForeignKey(s => s.ProblemId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
