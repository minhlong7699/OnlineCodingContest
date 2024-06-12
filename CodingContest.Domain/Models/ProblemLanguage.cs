using System;
using CodingContest.Domain.Abstractions;

namespace CodingContest.Domain.Models
{
    public class ProblemLanguage : Entity<Guid>
    {
        public Guid ProblemId { get; private set; }
        public Guid LanguageId { get; private set; }
        public string DefaultCode { get; private set; }
        public bool IsActive { get; private set; }

        public Problem Problem { get; private set; }
        public Language Language { get; private set; }

        private ProblemLanguage() { }

        public ProblemLanguage(Guid problemId, Guid languageId, string defaultCode)
        {
            ProblemId = problemId;
            LanguageId = languageId;
            DefaultCode = defaultCode;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            LastModifie = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
            LastModifie = DateTime.UtcNow;
        }
    }
}
