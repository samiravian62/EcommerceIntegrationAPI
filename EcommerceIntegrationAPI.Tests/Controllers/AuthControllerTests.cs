using EcommerceIntegrationAPI.Controllers;
using EcommerceIntegrationAPI.Models;
using EcommerceIntegrationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class AuthControllerTests
{
    private readonly Mock<IAuthService> _mockAuthService;
    private readonly Mock<ITokenService> _mockTokenService;
    private readonly AuthController _controller;

    public AuthControllerTests()
    {
        _mockAuthService = new Mock<IAuthService>();
        _mockTokenService = new Mock<ITokenService>();

        _controller = new AuthController(_mockAuthService.Object, _mockTokenService.Object);
    }

    [Fact]
    public void GenerateToken_ReturnsToken_WhenCredentialsAreValid()
    {
        // Arrange
        var loginRequest = new LoginRequest { Username = "admin", Password = "Admin@123" };
        var user = new User { Username = "admin", Role = "Admin" };
        _mockAuthService.Setup(x => x.Authenticate(loginRequest.Username, loginRequest.Password)).Returns(user);
        _mockTokenService.Setup(x => x.GenerateToken(user)).Returns("fake-jwt-token");

        // Act
        var result = _controller.GenerateToken(loginRequest) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Contains("token", result.Value.ToString());
    }

    [Fact]
    public void GenerateToken_ReturnsUnauthorized_WhenCredentialsAreInvalid()
    {
        // Arrange
        var loginRequest = new LoginRequest { Username = "admin", Password = "wrongpassword" };
        _mockAuthService.Setup(x => x.Authenticate(loginRequest.Username, loginRequest.Password)).Returns((User)null);

        // Act
        var result = _controller.GenerateToken(loginRequest);

        // Assert
        Assert.IsType<UnauthorizedObjectResult>(result);
    }
}
