using System;
using CodingContest.Domain.Abstractions;
using CodingContest.Domain.Enums;
using CodingContest.Domain.Events;
using CodingContest.Domain.ValueObjects;

namespace CodingContest.Domain.Models
{
    public class User : AggregateRoot<Guid>
    {
        public Username Username { get; private set; }
        public Email Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime DOB { get; private set; }
        public Address Address { get; private set; }
        public string Bio { get; private set; }
        public string ProfilePictureUrl { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime? LastLogin { get; private set; }

        public ICollection<UserToken> UserTokens { get; private set; } = new List<UserToken>();
        public ICollection<UserLog> UserLogs { get; private set; } = new List<UserLog>();
        public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();
        public ICollection<UserPasswordReset> UserPasswordResets { get; private set; } = new List<UserPasswordReset>();
        public ICollection<UserSolvedProblem> UserSolvedProblems { get; private set; } = new List<UserSolvedProblem>();
        public ICollection<Submission> Submissions { get; private set; } = new List<Submission>();
        public ICollection<ContestLeaderboard> ContestLeaderboards { get; private set; } = new List<ContestLeaderboard>();

        private User() { }

        public static User Create(Guid id, Username username, Email email, string passwordHash, string passwordSalt,  Gender gender, DateTime dob, Address address ,string bio, string profilePictureUrl)
        {
            var user = new User
            {
                Id = id,
                Username = username,
                Email = email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Gender = gender,
                DOB = dob,
                Address = address,
                Bio = bio,
                ProfilePictureUrl = profilePictureUrl,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                LastModifie = DateTime.UtcNow
            };

            user.AddDomainEvent(new UserCreatedEvent(user));

            return user;
        }

        public void UpdateProfile(Address newAddress, Gender gender, string bio, string profilePictureUrl)
        {
            Address = newAddress;
            Gender = gender;
            Bio = bio;
            ProfilePictureUrl = profilePictureUrl;
            LastModifie = DateTime.UtcNow;

            AddDomainEvent(new UserUpdatedEvent(this));
        }

        public void Deactivate()
        {
            IsActive = false;
            LastModifie = DateTime.UtcNow;

            AddDomainEvent(new UserDeactivatedEvent(this));
        }

        public void RecordLogin()
        {
            LastLogin = DateTime.UtcNow;
            LastModifie = DateTime.UtcNow;
        }


        public void ResetPassword(string passwordHash, string passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            LastModifie = DateTime.UtcNow;

            AddDomainEvent(new UserPasswordResetEvent(this));
        }
    }
}
