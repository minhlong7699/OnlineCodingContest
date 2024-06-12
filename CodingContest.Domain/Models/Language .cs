using System;
using System.Collections.Generic;
using CodingContest.Domain.Abstractions;

namespace CodingContest.Domain.Models
{
    public class Language : Entity<Guid>
    {
        public string LanguageName { get; private set; }
        public string DefaultCode { get; private set; }
        public bool IsActive { get; private set; }

        public ICollection<ProblemLanguage> ProblemLanguages { get; private set; } = new List<ProblemLanguage>();

        private Language() { }

        public static Language Create(Guid id, string languageName, string defaultCode)
        {
            return new Language
            {
                Id = id,
                LanguageName = languageName,
                DefaultCode = defaultCode,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                LastModifie = DateTime.UtcNow
            };
        }

        public void Update(string languageName, string defaultCode)
        {
            LanguageName = languageName;
            DefaultCode = defaultCode;
            LastModifie = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
            LastModifie = DateTime.UtcNow;
        }
    }
}
