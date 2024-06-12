using System;
using CodingContest.Domain.Abstractions;

namespace CodingContest.Domain.Models
{
    public class DailyProblem : Entity<Guid>
    {
        public Guid ProblemId { get; private set; }
        public string DataType { get; private set; }

        public Problem Problem { get; private set; }

        private DailyProblem() { }

        public DailyProblem(Guid problemId, string dataType)
        {
            ProblemId = problemId;
            DataType = dataType;
            CreatedAt = DateTime.UtcNow;
            LastModifie = DateTime.UtcNow;
        }
    }
}
