using System;
using CodingContest.Domain.Abstractions;

namespace CodingContest.Domain.Models
{
    public class Tag : Entity<Guid>
    {
        public string TagName { get; private set; }
        public string HtmlTagColor { get; private set; }
        public bool IsActive { get; private set; }

        public ICollection<ProblemTag> ProblemTags { get; private set; } = new List<ProblemTag>();

        private Tag() { }

        public static Tag Create(Guid id, string tagName, string htmlTagColor)
        {
            return new Tag
            {
                Id = id,
                TagName = tagName,
                HtmlTagColor = htmlTagColor,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                LastModifie = DateTime.UtcNow
            };
        }

        public void Update(string tagName, string htmlTagColor)
        {
            TagName = tagName;
            HtmlTagColor = htmlTagColor;
            LastModifie = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
            LastModifie = DateTime.UtcNow;
        }
    }
}
