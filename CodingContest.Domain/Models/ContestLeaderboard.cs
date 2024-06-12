using System;
using CodingContest.Domain.Abstractions;

namespace CodingContest.Domain.Models
{
    public class ContestLeaderboard : Entity<Guid>
    {
        public Guid ContestId { get; private set; }
        public Guid UserId { get; private set; }
        public int TotalScore { get; private set; }
        public float TotalExecutionTime { get; private set; }

        public Contest Contest { get; private set; }
        public User User { get; private set; }

        private ContestLeaderboard() { }

        public ContestLeaderboard(Guid contestId, Guid userId, int totalScore, float totalExecutionTime)
        {
            ContestId = contestId;
            UserId = userId;
            TotalScore = totalScore;
            TotalExecutionTime = totalExecutionTime;
            CreatedAt = DateTime.UtcNow;
            LastModifie = DateTime.UtcNow;
        }

        public void Update(int totalScore, float totalExecutionTime)
        {
            TotalScore = totalScore;
            TotalExecutionTime = totalExecutionTime;
            LastModifie = DateTime.UtcNow;
        }
    }
}
