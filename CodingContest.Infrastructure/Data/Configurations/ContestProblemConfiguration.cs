using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class ContestProblemConfiguration : IEntityTypeConfiguration<ContestProblem>
    {
        public void Configure(EntityTypeBuilder<ContestProblem> builder)
        {
            builder.HasKey(cp => new { cp.ContestId, cp.ProblemId });
            builder.Property(cp => cp.ContestId).IsRequired();
            builder.Property(cp => cp.ProblemId).IsRequired();

            builder.HasOne(cp => cp.Contest)
                   .WithMany(c => c.ContestProblems)
                   .HasForeignKey(cp => cp.ContestId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cp => cp.Problem)
                   .WithMany(p => p.ContestProblems)
                   .HasForeignKey(cp => cp.ProblemId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
