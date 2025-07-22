using EcommerceIntegrationAPI.Models;

namespace EcommerceIntegrationAPI.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
