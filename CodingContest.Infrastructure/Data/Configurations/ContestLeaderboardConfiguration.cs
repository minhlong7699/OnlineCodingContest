using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class ContestLeaderboardConfiguration : IEntityTypeConfiguration<ContestLeaderboard>
    {
        public void Configure(EntityTypeBuilder<ContestLeaderboard> builder)
        {
            builder.HasKey(cl => cl.Id);
            builder.Property(cl => cl.ContestId).IsRequired();
            builder.Property(cl => cl.UserId).IsRequired();
            builder.Property(cl => cl.TotalScore).IsRequired();
            builder.Property(cl => cl.TotalExecutionTime).IsRequired();

            builder.HasOne(cl => cl.User)
                   .WithMany(u => u.ContestLeaderboards)
                   .HasForeignKey(cl => cl.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cl => cl.Contest)
                   .WithMany(c => c.ContestLeaderboards)
                   .HasForeignKey(cl => cl.ContestId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
