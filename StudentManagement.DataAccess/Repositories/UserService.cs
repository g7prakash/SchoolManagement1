﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentManagement.DataAccess.Contexts;
using StudentManagement.DataAccess.Helpers;
using StudentManagement.DataAccess.Interfaces;
using StudentManagement.Models;
using StudentManagement.Models.Users;
using System.Collections;

namespace StudentManagement.DataAccess.Repositories
{
    public class UserService : IUserService
    {
        private SchoolDbContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IConfiguration _configuration;


        public UserService(
            SchoolDbContext context,
            IJwtUtils jwtUtils,
            IConfiguration configuration

            )
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _configuration = configuration;


        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress)
        {
            var user = _context.JWTUsers.SingleOrDefault(x => x.Username == model.Username);

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            var refreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
            user.RefreshTokens.Add(refreshToken);

            // remove old refresh tokens from user
            removeOldRefreshTokens(user);

            // save changes to db
            var JWTUsersObj = _context.JWTUsers.Attach(user);
            JWTUsersObj.State = EntityState.Modified;

            _context.SaveChanges();

            return new AuthenticateResponse(user, jwtToken, refreshToken.Token);
        }

        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            var user = getUserByRefreshToken(token);
            var refreshToken = user.RefreshTokens.LastOrDefault(x => x.Token == token);

            if (refreshToken != null && refreshToken.IsRevoked)
            {
                // revoke all descendant tokens in case this token has been compromised
                revokeDescendantRefreshTokens(refreshToken, user, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
                _context.Update(user);
                _context.SaveChanges();
            }

            if (!refreshToken.IsActive)
                throw new AppException("Invalid token");

            // replace old refresh token with a new one (rotate token)
            var newRefreshToken = rotateRefreshToken(refreshToken, ipAddress);
            user.RefreshTokens.Add(newRefreshToken);

            // remove old refresh tokens from user
            removeOldRefreshTokens(user);

            // save changes to db
            _context.Update(user);
            _context.SaveChanges();

            // generate new jwt
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken, newRefreshToken.Token);
        }

        public void RevokeToken(string token, string ipAddress)
        {
            var user = getUserByRefreshToken(token);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            if (!refreshToken.IsActive)
                throw new AppException("Invalid token");

            // revoke token and save
            revokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");
            _context.Update(user);
            _context.SaveChanges();
        }

        // Note: Used by the Angular Client to show all Users !
        public IEnumerable<User> GetAll()
        {
            return _context.JWTUsers;
        }


        // TEST
        // Select all columns from the Account and the RefreshToken Table
        public IEnumerable<User> GetAllX()
        {
            return _context.JWTUsers;
        }

        // TEST
        // Select only specific columns from the Account Table and all columns from the RefreshToken Table
        public IEnumerable GetAllY()
        {
            var query = _context.JWTUsers.Select(x => new
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,

                RefreshTokens = x.RefreshTokens
            }

           // ToList() works ok but the Json structure output is less fine for read
           //  ).AsNoTracking().ToList();

           // My recomendation !
           // AsEnumerable() works fine - and may be a better choise 
           // with performance improvement on large dataset
           // Anyway both List and Enumerable using less memory alocation than arrays
           // This gives a more clean Json output than ToList ! 
           ).AsNoTracking().AsEnumerable();

            return query;

        }

        // TEST
        // Select only specific columns from the Account and the RefreshToken Table 
        public IEnumerable GetAllZ()
        {
            var query = _context.JWTUsers.Select(x => new
            {
                Id = x.Id,

                FirstName = x.FirstName,
                LastName = x.LastName,

                // Select specific columns from the RefreshToken Table
                RefreshTokens = x.RefreshTokens.Select(x => new
                {
                    Id = x.Id,
                    Token = x.Token,
                    Expires = x.Expires
                }
                  )
            }

           ).AsNoTracking().AsEnumerable();

            return query;
        }


        public User GetById(int id)
        {
            var user = _context.JWTUsers.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public void AddJWTUsers()
        {
            User user = new User() { FirstName = "Admin", LastName="admin-21-04-2025", Username="admin", PasswordHash=BCrypt.Net.BCrypt.HashPassword("admin")};
            _context.Add(user);
            _context.SaveChanges();
        }
        // helper methods

        private User getUserByRefreshToken(string token)
        {
            var user = _context.JWTUsers.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
                throw new AppException("Invalid token");

            return user;
        }

        private RefreshToken rotateRefreshToken(RefreshToken refreshToken, string ipAddress)
        {
            var newRefreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
            revokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return newRefreshToken;
        }

        private void removeOldRefreshTokens(User user)
        {
            // remove old inactive refresh tokens from user based on TTL in app settings
            user.RefreshTokens.RemoveAll(x =>
                !x.IsActive &&
                x.Created.AddDays(Convert.ToDouble(_configuration["AppSettings:RefreshTokenTTL"])) <= DateTime.UtcNow);
        }

        private void revokeDescendantRefreshTokens(RefreshToken refreshToken, User user, string ipAddress, string reason)
        {
            // recursively traverse the refresh token chain and ensure all descendants are revoked
            if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            {
                var childToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);
                if (childToken.IsActive)
                    revokeRefreshToken(childToken, ipAddress, reason);
                else
                    revokeDescendantRefreshTokens(childToken, user, ipAddress, reason);
            }
        }

        private void revokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
        }
    }
}
