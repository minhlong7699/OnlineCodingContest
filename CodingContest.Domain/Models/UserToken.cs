using System;
using CodingContest.Domain.Abstractions;

namespace CodingContest.Domain.Models
{
    public class UserToken : Entity<Guid>
    {
        public Guid UserId { get; private set; }
        public string AccessToken { get; private set; }
        public DateTime AccessTokenExpiryDate { get; private set; }
        public string RefreshToken { get; private set; }
        public DateTime RefreshTokenExpiryDate { get; private set; }


        public User User { get; private set; }

        private UserToken() { }

        public UserToken(Guid userId, string accessToken, DateTime accessTokenExpiryDate, string refreshToken, DateTime refreshTokenExpiryDate)
        {
            UserId = userId;
            AccessToken = accessToken;
            AccessTokenExpiryDate = accessTokenExpiryDate;
            RefreshToken = refreshToken;
            RefreshTokenExpiryDate = refreshTokenExpiryDate;
            CreatedAt = DateTime.UtcNow;
            LastModifie = DateTime.UtcNow;
        }

        public void UpdateTokens(string accessToken, DateTime accessTokenExpiryDate, string refreshToken, DateTime refreshTokenExpiryDate)
        {
            AccessToken = accessToken;
            AccessTokenExpiryDate = accessTokenExpiryDate;
            RefreshToken = refreshToken;
            RefreshTokenExpiryDate = refreshTokenExpiryDate;
            LastModifie = DateTime.UtcNow;
        }
    }
}
