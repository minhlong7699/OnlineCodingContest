using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(ut => ut.Id);
            builder.Property(ut => ut.UserId).IsRequired();
            builder.Property(ut => ut.AccessToken).IsRequired().HasMaxLength(256);
            builder.Property(ut => ut.AccessTokenExpiryDate).IsRequired();
            builder.Property(ut => ut.RefreshToken).IsRequired().HasMaxLength(256);
            builder.Property(ut => ut.RefreshTokenExpiryDate).IsRequired();

            builder.HasOne(ut => ut.User)
                   .WithMany(u => u.UserTokens)
                   .HasForeignKey(ut => ut.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
