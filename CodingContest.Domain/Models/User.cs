using System;
using CodingContest.Domain.Abstractions;
using CodingContest.Domain.Events;

namespace CodingContest.Domain.Models
{
    public class User : AggregateRoot<Guid>
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Gender { get; private set; }
        public DateTime DOB { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Bio { get; private set; }
        public string ProfilePictureUrl { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime? LastLogin { get; private set; }

        private User() { }

        public static User Create(Guid id, string username, string email, string passwordHash, string passwordSalt, string firstName, string lastName, string gender, DateTime dob, string country, string city, string bio, string profilePictureUrl)
        {
            var user = new User
            {
                Id = id,
                Username = username,
                Email = email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                DOB = dob,
                Country = country,
                City = city,
                Bio = bio,
                ProfilePictureUrl = profilePictureUrl,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                LastModifie = DateTime.UtcNow
            };

            user.AddDomainEvent(new UserCreatedEvent(user));

            return user;
        }

        public void UpdateProfile(string firstName, string lastName, string gender, string country, string city, string bio, string profilePictureUrl)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Country = country;
            City = city;
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
    }
}
