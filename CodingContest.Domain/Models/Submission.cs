using System;
using CodingContest.Domain.Abstractions;

namespace CodingContest.Domain.Models
{
    public class Submission : Entity<Guid>
    {
        public Guid UserId { get; private set; }
        public Guid ProblemId { get; private set; }
        public Guid? ContestId { get; private set; }
        public string Code { get; private set; }
        public string Language { get; private set; }
        public string Status { get; private set; }
        public int Score { get; private set; }
        public float ExecutionTime { get; private set; }
        public float MemoryUsage { get; private set; }
        public string ErrorMessage { get; private set; }

        public User User { get; private set; }
        public Problem Problem { get; private set; }
        public Contest? Contest { get; private set; }

        public ICollection<ExecutionResult> ExecutionResults { get; private set; } = new List<ExecutionResult>();
        private Submission() { }

        public static Submission Create(Guid id, Guid userId, Guid problemId, Guid contestId, string code, string language, string status, int score, float executionTime, float memoryUsage, string errorMessage)
        {
            return new Submission
            {
                Id = id,
                UserId = userId,
                ProblemId = problemId,
                ContestId = contestId,
                Code = code,
                Language = language,
                Status = status,
                Score = score,
                ExecutionTime = executionTime,
                MemoryUsage = memoryUsage,
                ErrorMessage = errorMessage,
                CreatedAt = DateTime.UtcNow,
                LastModifie = DateTime.UtcNow
            };
        }

        public void Update(string status, int score, float executionTime, float memoryUsage, string errorMessage)
        {
            Status = status;
            Score = score;
            ExecutionTime = executionTime;
            MemoryUsage = memoryUsage;
            ErrorMessage = errorMessage;
            LastModifie = DateTime.UtcNow;
        }
    }
}
