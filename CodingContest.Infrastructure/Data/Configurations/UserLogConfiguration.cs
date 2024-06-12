using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class UserLogConfiguration : IEntityTypeConfiguration<UserLog>
    {
        public void Configure(EntityTypeBuilder<UserLog> builder)
        {
            builder.HasKey(ul => ul.Id);
            builder.Property(ul => ul.UserId).IsRequired();
            builder.Property(ul => ul.Action).IsRequired().HasMaxLength(1000);
            builder.Property(ul => ul.LogTime).IsRequired();

            builder.HasOne(ul => ul.User)
                   .WithMany(u => u.UserLogs)
                   .HasForeignKey(ul => ul.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
