using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Code).IsRequired().HasMaxLength(10000);
            builder.Property(s => s.Language).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Status).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Score).IsRequired();
            builder.Property(s => s.ExecutionTime).IsRequired();
            builder.Property(s => s.MemoryUsage).IsRequired();
            builder.Property(s => s.ErrorMessage).HasMaxLength(2000);

            builder.HasOne(s => s.User)
                   .WithMany(u => u.Submissions)
                   .HasForeignKey(s => s.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Problem)
                   .WithMany(p => p.Submissions)
                   .HasForeignKey(s => s.ProblemId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Contest)
                   .WithMany(c => c.Submissions)
                   .HasForeignKey(s => s.ContestId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.ExecutionResults)
                   .WithOne(er => er.Submission)
                   .HasForeignKey(er => er.SubmissionId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
