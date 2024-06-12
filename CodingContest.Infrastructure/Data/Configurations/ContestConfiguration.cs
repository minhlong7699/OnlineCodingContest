using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;
using CodingContest.Domain.ValueObjects;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class ContestConfiguration : IEntityTypeConfiguration<Contest>
    {
        public void Configure(EntityTypeBuilder<Contest> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                   .HasConversion(
                       v => v.Value,
                       v => Title.Of(v))
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.Description)
                   .HasConversion(
                       v => v.Value,
                       v => Description.Of(v))
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(c => c.StartTime).IsRequired();
            builder.Property(c => c.EndTime).IsRequired();

            builder.HasMany(c => c.ContestLeaderboards)
                   .WithOne(cl => cl.Contest)
                   .HasForeignKey(cl => cl.ContestId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.ContestProblems)
                   .WithOne(cp => cp.Contest)
                   .HasForeignKey(cp => cp.ContestId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Submissions)
                   .WithOne(s => s.Contest)
                   .HasForeignKey(s => s.ContestId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
