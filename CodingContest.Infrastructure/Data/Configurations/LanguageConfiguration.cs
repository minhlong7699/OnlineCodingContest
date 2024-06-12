using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.LanguageName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(l => l.DefaultCode).IsRequired();
            builder.Property(l => l.IsActive).IsRequired();

            builder.HasMany(l => l.ProblemLanguages)
                   .WithOne(pl => pl.Language)
                   .HasForeignKey(pl => pl.LanguageId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
