using Xunit;
using Moq;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerInfrastructure.Services;
using LingoPartnerDomain.enums;
using System.Net.Mail;

namespace LingoPartnerTests.authentication
{
  public class AuthenticationServiceTests
  {
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly AuthenticationService _authenticationService;

    public AuthenticationServiceTests()
    {
      _userRepositoryMock = new Mock<IUserRepository>();
      _authenticationService = new AuthenticationService(_userRepositoryMock.Object);
    }

    [Fact]
    public void Authenticate_ValidCredentials_ReturnsTrue()
    {
      // Arrange
      var username = "admin";
      var password = "start1234!";
      var user = new User(
        "admin",
        null,
        "admin",
        new DateTime(1990, 1, 1),
        new MailAddress("admin@tpm.nl"),
        password,
        username,
        UserRole.ADMIN
      );

      _userRepositoryMock.Setup(repo => repo.GetBy(username)).Returns(user);
      // _userRepositoryMock.Setup(repo => repo.(password)).Returns(true);
      _authenticationService.Authenticate(username, password);

      // Act
      var result = _authenticationService.Authenticate(username, password);

      // Assert
      Assert.True(result);
      Assert.Equal(user, _authenticationService.CurrentUser);
    }

    [Fact]
    public void Authenticate_InvalidCredentials_ReturnsFalse()
    {
      // Arrange
      var username = "admin";
      var password = "start1234!";
      var invalidPassword = "invalidPassword";
      var user = new User(
        "admin",
        null,
        "admin",
        new DateTime(1990, 1, 1),
        new MailAddress("admin@tpm.nl"),
        invalidPassword,
        username,
        UserRole.ADMIN
      );


      _userRepositoryMock.Setup(repo => repo.GetBy(username)).Returns(user);

      // Act
      var result = _authenticationService.Authenticate(username, password);

      // Assert
      Assert.False(result);
      Assert.Null(_authenticationService.CurrentUser);
    }

    [Fact]
    public void Authenticate_UserNotFound_ReturnsFalse()
    {
      // Arrange
      var username = "nonexistentuser";
      var password = "anyPassword";

      _userRepositoryMock.Setup(repo => repo.GetBy(username)).Returns((User)null);

      // Act
      var result = _authenticationService.Authenticate(username, password);

      // Assert
      Assert.False(result);
      Assert.Null(_authenticationService.CurrentUser);
    }
  }
}
