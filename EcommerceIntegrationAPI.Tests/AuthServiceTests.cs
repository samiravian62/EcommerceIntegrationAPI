using EcommerceIntegrationAPI.Data;
using EcommerceIntegrationAPI.Models;
using EcommerceIntegrationAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EcommerceIntegrationAPI.Tests
{
    public class AuthServiceTests
    {
        private EcommerceDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<EcommerceIntegrationAPI.Data.EcommerceDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            var context = new EcommerceIntegrationAPI.Data.EcommerceDbContext(options);

            // Seed a test user
            context.Users.Add(new User
            {
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                Role = "Admin"
            });
            context.SaveChanges();

            return context;
        }

        [Fact]
        public void Authenticate_WithValidCredentials_ReturnsUser()
        {
            var context = GetInMemoryDbContext();
            var authService = new AuthService(context);

            var user = authService.Authenticate("admin", "Admin@123");

            Assert.NotNull(user);
            Assert.Equal("admin", user.Username);
        }

        [Fact]
        public void Authenticate_WithInvalidPassword_ReturnsNull()
        {
            var context = GetInMemoryDbContext();
            var authService = new AuthService(context);

            var user = authService.Authenticate("admin", "WrongPassword");

            Assert.Null(user);
        }

        [Fact]
        public void Authenticate_WithNonExistentUser_ReturnsNull()
        {
            var context = GetInMemoryDbContext();
            var authService = new AuthService(context);

            var user = authService.Authenticate("notexist", "Admin@123");

            Assert.Null(user);
        }
    }
}
