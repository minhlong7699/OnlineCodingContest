using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class ProblemLanguageConfiguration : IEntityTypeConfiguration<ProblemLanguage>
    {
        public void Configure(EntityTypeBuilder<ProblemLanguage> builder)
        {
            builder.HasKey(pl => pl.Id);

            builder.Property(pl => pl.ProblemId).IsRequired();
            builder.Property(pl => pl.LanguageId).IsRequired();
            builder.Property(pl => pl.DefaultCode).IsRequired().HasMaxLength(2000);
            builder.Property(pl => pl.IsActive).IsRequired();

            builder.HasOne(pl => pl.Problem)
                   .WithMany(p => p.ProblemLanguages)
                   .HasForeignKey(pl => pl.ProblemId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pl => pl.Language)
                   .WithMany(l => l.ProblemLanguages)
                   .HasForeignKey(pl => pl.LanguageId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
