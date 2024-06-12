using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class UserPasswordResetConfiguration : IEntityTypeConfiguration<UserPasswordReset>
    {
        public void Configure(EntityTypeBuilder<UserPasswordReset> builder)
        {
            builder.HasKey(upr => upr.Id);
            builder.Property(upr => upr.UserId).IsRequired();
            builder.Property(upr => upr.Token).IsRequired().HasMaxLength(256);
            builder.Property(upr => upr.ExpiryDate).IsRequired();

            builder.HasOne(upr => upr.User)
                   .WithMany(u => u.UserPasswordResets)
                   .HasForeignKey(upr => upr.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
