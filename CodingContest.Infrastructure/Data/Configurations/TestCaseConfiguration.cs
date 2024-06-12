using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class TestCaseConfiguration : IEntityTypeConfiguration<TestCase>
    {
        public void Configure(EntityTypeBuilder<TestCase> builder)
        {
            builder.HasKey(tc => tc.Id);
            builder.Property(tc => tc.ProblemId).IsRequired();
            builder.Property(tc => tc.TestCaseInput).IsRequired().HasMaxLength(2000);
            builder.Property(tc => tc.ExpectedOutput).IsRequired().HasMaxLength(2000);
            builder.Property(tc => tc.IsSample).IsRequired();
            builder.Property(tc => tc.Description).HasMaxLength(1000);

            builder.HasOne(tc => tc.Problem)
                   .WithMany(p => p.TestCases)
                   .HasForeignKey(tc => tc.ProblemId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(tc => tc.ExecutionResults)
                   .WithOne(er => er.TestCase)
                   .HasForeignKey(er => er.TestCaseId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
