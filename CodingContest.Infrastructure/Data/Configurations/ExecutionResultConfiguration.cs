using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class ExecutionResultConfiguration : IEntityTypeConfiguration<ExecutionResult>
    {
        public void Configure(EntityTypeBuilder<ExecutionResult> builder)
        {
            builder.HasKey(er => er.Id);

            builder.Property(er => er.Input).IsRequired().HasMaxLength(2000);
            builder.Property(er => er.ExpectedOutput).IsRequired().HasMaxLength(2000);
            builder.Property(er => er.Status).IsRequired().HasMaxLength(100);

            builder.HasOne(er => er.Submission)
                   .WithMany(s => s.ExecutionResults)
                   .HasForeignKey(er => er.SubmissionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(er => er.TestCase)
                   .WithMany(tc => tc.ExecutionResults)
                   .HasForeignKey(er => er.TestCaseId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
