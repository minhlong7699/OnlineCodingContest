using System;
using CodingContest.Domain.Abstractions;

namespace CodingContest.Domain.Models
{
    public class UserSolvedProblem : Entity<Guid>
    {
        public Guid UserId { get; private set; }
        public Guid ProblemId { get; private set; }
        public DateTime SolvedDatetime { get; private set; }
        public string Status { get; private set; }

        private UserSolvedProblem() { }

        public UserSolvedProblem(Guid userId, Guid problemId, DateTime solvedDatetime, string status)
        {
            UserId = userId;
            ProblemId = problemId;
            SolvedDatetime = solvedDatetime;
            Status = status;
            CreatedAt = DateTime.UtcNow;
            LastModifie = DateTime.UtcNow;
        }

        public void UpdateStatus(string status)
        {
            Status = status;
            LastModifie = DateTime.UtcNow;
        }
    }
}
