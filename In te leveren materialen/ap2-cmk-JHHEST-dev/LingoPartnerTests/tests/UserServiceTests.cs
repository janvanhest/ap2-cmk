using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerDomain.Services;
using Moq;
using Xunit;

namespace LingoPartnerTests.UserServiceTests
{
  public class UserServiceTests
  {
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly IUserService _userService;

    public UserServiceTests()
    {
      _mockUserRepository = new Mock<IUserRepository>();
      _userService = new UserService(_mockUserRepository.Object);
    }

    [Fact]
    public void RegisterUser_ShouldReturnUser_WhenUserIsRegisteredSuccessfully()
    {
      // Arrange
      var user = new User(1, "John", "", "Doe", new DateTime(1990, 1, 1), new MailAddress("john@doe.nl"), "password123", "johndoe", UserRole.ADMIN);
      _mockUserRepository.Setup(repo => repo.Add(It.IsAny<User>(), It.IsAny<string>())).Returns(user);

      // Act
      var result = _userService.RegisterUser(user, "password123");

      // Assert
      Assert.NotNull(result);
      Assert.Equal(user.Id, result?.Id);
    }

    [Fact]
    public void GetAllUsers_ShouldReturnAllUsers()
    {
      // Arrange
      var users = new List<User>
            {
                new User(1, "John", "", "Doe", new DateTime(1990, 1, 1), new MailAddress("john@doe.nl"), "password123", "johndoe", UserRole.ADMIN),
                new User(2, "Jane", "", "Doe", new DateTime(1992, 2, 2), new MailAddress("jane@doe.nl"), "password123", "janedoe", UserRole.STUDENT)
            };
      _mockUserRepository.Setup(repo => repo.GetAll()).Returns(users);

      // Act
      var result = _userService.GetAllUsers();

      // Assert
      Assert.NotNull(result);
      Assert.Equal(2, result.Count());
    }

    [Fact]
    public void UpdateUser_ShouldReturnUpdatedUser_WhenUpdateIsSuccessful()
    {
      // Arrange
      var user = new User(1, "John", "", "Doe", new DateTime(1990, 1, 1), new MailAddress("john@doe.nl"), "password123", "johndoe", UserRole.ADMIN);
      _mockUserRepository.Setup(repo => repo.Update(It.IsAny<User>(), It.IsAny<string>())).Returns(user);

      // Act
      var result = _userService.UpdateUser(user, "newpassword123");

      // Assert
      Assert.NotNull(result);
      Assert.Equal(user.Id, result?.Id);
    }

    [Fact]
    public void GetUserByUsername_ShouldReturnUser_WhenUserExists()
    {
      // Arrange
      var user = new User(1, "John", "", "Doe", new DateTime(1990, 1, 1), new MailAddress("john@doe.nl"), "password123", "johndoe", UserRole.ADMIN);
      _mockUserRepository.Setup(repo => repo.GetBy(It.IsAny<string>())).Returns(user);

      // Act
      var result = _userService.GetUserByUsername("johndoe");

      // Assert
      Assert.NotNull(result);
      Assert.Equal(user.Id, result?.Id);
    }

    [Fact]
    public void GetUserByUsername_ShouldReturnNull_WhenUserDoesNotExist()
    {
      // Arrange
      _mockUserRepository.Setup(repo => repo.GetBy(It.IsAny<string>())).Returns((User)null);

      // Act
      var result = _userService.GetUserByUsername("nonexistentuser");

      // Assert
      Assert.Null(result);
    }
  }
}
