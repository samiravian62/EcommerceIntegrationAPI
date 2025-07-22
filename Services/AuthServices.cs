using EcommerceIntegrationAPI.Data;
using EcommerceIntegrationAPI.Models;
using EcommerceIntegrationAPI.Services.Interfaces;

namespace EcommerceIntegrationAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly EcommerceDbContext _context;

        public AuthService(EcommerceDbContext context)
        {
            _context = context;
        }

        public User? Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return user;
        }
    }
}