using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;
using CodingContest.Domain.ValueObjects;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                   .HasConversion(
                       v => v.Value,
                       v => Username.Of(v))
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Email)
                   .HasConversion(
                       v => v.Value,
                       v => Email.Of(v))
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(u => u.PasswordSalt)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(u => u.Gender)
                   .IsRequired();

            builder.Property(u => u.DOB)
                   .IsRequired();

            builder.OwnsOne(u => u.Address, a =>
            {
                a.Property(ad => ad.FirstName).HasMaxLength(50).IsRequired();
                a.Property(ad => ad.LastName).HasMaxLength(50).IsRequired();
                a.Property(ad => ad.Street).HasMaxLength(200).IsRequired();
                a.Property(ad => ad.City).HasMaxLength(100).IsRequired();
                a.Property(ad => ad.State).HasMaxLength(100).IsRequired();
                a.Property(ad => ad.Country).HasMaxLength(100).IsRequired();
                a.Property(ad => ad.ZipCode).HasMaxLength(20).IsRequired();
            });

            builder.Property(u => u.Bio)
                   .HasMaxLength(1000);

            builder.Property(u => u.ProfilePictureUrl)
                   .HasMaxLength(256);

            builder.Property(u => u.IsActive)
                   .IsRequired();

            builder.Property(u => u.LastLogin);

            // Configure relationships with other tables
            builder.HasMany(u => u.UserTokens)
                   .WithOne(ut => ut.User)
                   .HasForeignKey(ut => ut.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserLogs)
                   .WithOne(ul => ul.User)
                   .HasForeignKey(ul => ul.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserRoles)
                   .WithOne(ur => ur.User)
                   .HasForeignKey(ur => ur.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserPasswordResets)
                   .WithOne(upr => upr.User)
                   .HasForeignKey(upr => upr.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserSolvedProblems)
                   .WithOne(usp => usp.User)
                   .HasForeignKey(usp => usp.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Submissions)
                   .WithOne(s => s.User)
                   .HasForeignKey(s => s.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.ContestLeaderboards)
                   .WithOne(cl => cl.User)
                   .HasForeignKey(cl => cl.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
