using EcommerceIntegrationAPI.Models;

namespace EcommerceIntegrationAPI.Services.Interfaces
{
    public interface IAuthService
    {
        User? Authenticate(string username, string password);
    }
}
