using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class ProblemTagConfiguration : IEntityTypeConfiguration<ProblemTag>
    {
        public void Configure(EntityTypeBuilder<ProblemTag> builder)
        {
            builder.HasKey(pt => new { pt.ProblemId, pt.TagId });
            builder.Property(pt => pt.ProblemId).IsRequired();
            builder.Property(pt => pt.TagId).IsRequired();

            builder.HasOne(pt => pt.Problem)
                   .WithMany()
                   .HasForeignKey(pt => pt.ProblemId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.Tag)
                   .WithMany(t => t.ProblemTags)
                   .HasForeignKey(pt => pt.TagId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
