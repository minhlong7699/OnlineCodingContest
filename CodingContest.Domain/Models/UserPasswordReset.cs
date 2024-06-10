using System;
using CodingContest.Domain.Abstractions;

namespace CodingContest.Domain.Models
{
    public class UserPasswordReset : Entity<Guid>
    {
        public Guid UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime ExpiryDate { get; private set; }

        private UserPasswordReset() { }

        public UserPasswordReset(Guid userId, string token, DateTime expiryDate)
        {
            UserId = userId;
            Token = token;
            ExpiryDate = expiryDate;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
