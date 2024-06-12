using System;
using CodingContest.Domain.Abstractions;

namespace CodingContest.Domain.Models
{
    public class UserLog : Entity<Guid>
    {
        public Guid UserId { get; private set; }
        public string Action { get; private set; }
        public DateTime LogTime { get; private set; }

        public User User { get; private set; }

        private UserLog() { }

        public UserLog(Guid userId, string action, DateTime logTime)
        {
            UserId = userId;
            Action = action;
            LogTime = logTime;
        }
    }
}
