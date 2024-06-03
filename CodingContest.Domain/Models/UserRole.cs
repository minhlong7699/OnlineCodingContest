using System;
using CodingContest.Domain.Abstractions;

namespace CodingContest.Domain.Models
{
    public class UserRole : Entity<Guid>
    {
        public Guid UserId { get; private set; }
        public Guid RoleId { get; private set; }

        private UserRole() { }

        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
            CreatedAt = DateTime.UtcNow;
            LastModifie = DateTime.UtcNow;
        }
    }
}
