using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CodingContest.Domain.Models;

namespace CodingContest.Infrastructure.Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TagName).IsRequired().HasMaxLength(100);
            builder.Property(t => t.HtmlTagColor).IsRequired().HasMaxLength(7);
            builder.Property(t => t.IsActive).IsRequired();
        }
    }
}
