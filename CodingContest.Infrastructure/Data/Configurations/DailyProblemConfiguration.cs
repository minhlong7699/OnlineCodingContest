using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class DailyProblemConfiguration : IEntityTypeConfiguration<DailyProblem>
    {
        public void Configure(EntityTypeBuilder<DailyProblem> builder)
        {
            builder.HasKey(dp => dp.Id);

            builder.Property(dp => dp.ProblemId).IsRequired();
            builder.Property(dp => dp.DataType).IsRequired().HasMaxLength(100);

            builder.HasOne(dp => dp.Problem)
                   .WithMany(p => p.DailyProblems)
                   .HasForeignKey(dp => dp.ProblemId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
