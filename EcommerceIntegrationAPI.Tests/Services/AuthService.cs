using EcommerceIntegrationAPI.Data;
using EcommerceIntegrationAPI.Models;
using EcommerceIntegrationAPI.Services.Interfaces;

public class AuthService : IAuthService
{
    private readonly EcommerceDbContext _context;

    public AuthService(EcommerceDbContext context)
    {
        _context = context;
    }

    public User Authenticate(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        if (user == null)
            return null;

        bool verified = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        return verified ? user : null;
    }
}
