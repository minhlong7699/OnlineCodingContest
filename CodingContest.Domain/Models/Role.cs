using System;
using CodingContest.Domain.Abstractions;

namespace CodingContest.Domain.Models
{
    public class Role : Entity<Guid>
    {
        public string Name { get; private set; }

        public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();

        private Role() { }

        public Role(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void UpdateName(string name)
        {
            Name = name;
            LastModifie = DateTime.UtcNow;
        }
    }
}
