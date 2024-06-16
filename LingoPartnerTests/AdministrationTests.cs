using System.Net.Mail;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;
using Moq;

namespace LingoPartnerTests.Domain
{
  public class AdministrationTests
  {
    // private readonly Mock<IUserRepository> mockUserRepository;
    // private readonly Mock<ILearningModuleRepository> mockLearningModuleRepository;
    // private readonly Mock<ILearningActivityRepository> mockLearningActivityRepository;
    // private readonly Mock<IProgressRepository> mockProgressRepository;
    // private readonly Mock<IAuthenticationService> mockAuthenticationService;
    // private readonly Mock<ILearningStreakService> mockLearningStreakService;
    // private readonly Mock<ILearningModuleService> mockLearningModuleService;
    // private readonly Administration administration;

    public AdministrationTests()
    {
      // mockUserRepository = new Mock<IUserRepository>();
      // mockLearningModuleRepository = new Mock<ILearningModuleRepository>();
      // mockLearningActivityRepository = new Mock<ILearningActivityRepository>();
      // mockProgressRepository = new Mock<IProgressRepository>();
      // mockAuthenticationService = new Mock<IAuthenticationService>();
      // mockLearningStreakService = new Mock<ILearningStreakService>();
      // mockLearningModuleService = new Mock<ILearningModuleService>();

      // administration = new Administration(
      //     mockUserRepository.Object,
      //     mockLearningModuleRepository.Object,
      //     mockLearningActivityRepository.Object,
      //     mockProgressRepository.Object,
      //     mockAuthenticationService.Object,
      //     mockLearningStreakService.Object,
      //     mockLearningModuleService.Object
      //     );
    }

    [Fact]
    public void AddUser_ShouldAddUser_WhenValidUser()
    {
      // Arrange
      // string firstName = "John";
      // string middleName = string.Empty;
      // string lastName = "Doe";
      // DateTime dateOfBirth = new DateTime(1990, 1, 1);
      // MailAddress email = new MailAddress("John@doe.nl");
      // string password = "Jaap1234!";
      // string username = "JohnDoe";
      // UserRole role = UserRole.STUDENT;

      // // Create user instance with an Id
      // User user = new User(1, firstName, middleName, lastName, dateOfBirth, email, password, username, role);

      // // Setup the mock repository to return the same user with an Id set
      // mockUserRepository.Setup(repo => repo.AddUser(It.IsAny<User>())).Returns(user);
      // mockUserRepository.Setup(repo => repo.GetUsers()).Returns(new List<User> { user });

      // // Act
      // administration.Add(user);

      // // Assert
      // User? addedUser = administration.Users.FirstOrDefault(u => u.Id == user.Id);
      // Assert.NotNull(addedUser);
      // Assert.Equal(user.Id, addedUser.Id);
      // Assert.Equal(firstName, addedUser.FirstName);
      // Assert.Equal(lastName, addedUser.LastName);
    }

    [Fact]
    public void AddLearningModule_ShouldAddLearningModule_WhenValidLearningModule()
    {
      // // Arrange
      // string name = "Module 1";
      // string description = "Module 1 description";
      // LearningModule module = new LearningModule(1, name, description);

      // mockLearningModuleRepository.Setup(repo => repo.AddLearningModule(It.IsAny<LearningModule>())).Returns(module);
      // mockLearningModuleRepository.Setup(repo => repo.GetAllLearningModules()).Returns(new List<LearningModule> { module });

      // // Act
      // administration.Add(module);

      // // Assert
      // LearningModule? addedModule = administration.LearningModules.FirstOrDefault(m => m.Id == module.Id);
      // Assert.NotNull(addedModule);
      // Assert.Equal(module.Id, addedModule.Id);
      // Assert.Equal(name, addedModule.Name);
    }

    [Fact]
    public void AddLearningActivity_ShouldAddLearningActivity_WhenValidLearningActivity()
    {
      // // Arrange
      // string name = "Activity 1";
      // string description = "Activity 1 description";
      // LearningActivityType type = LearningActivityType.INSTRUCTION;
      // int learningModuleId = 1;
      // LearningActivity activity = new LearningActivity(1, name, description, type, learningModuleId);
      // mockLearningModuleRepository.Setup(repo => repo.AddLearningModule(It.IsAny<LearningModule>())).Returns(new LearningModule(1, "Module 1", "Module 1 description"));
      // mockLearningModuleRepository.Setup(repo => repo.GetAllLearningModules()).Returns(new List<LearningModule> { new LearningModule(1, "Module 1", "Module 1 description") });

      // mockLearningActivityRepository.Setup(repo => repo.Add(It.IsAny<LearningActivity>())).Returns(activity);
      // mockLearningActivityRepository.Setup(repo => repo.GetAll()).Returns(new List<LearningActivity> { activity });

      // // Act
      // administration.Add(activity);
      // administration.RetrieveAllData();
      // // Assert
      // LearningActivity? addedActivity = administration.LearningActivities.FirstOrDefault(a => a.Id == activity.Id);
      // Assert.NotNull(addedActivity);
      // Assert.Equal(activity.Id, addedActivity.Id);
      // Assert.Equal(name, addedActivity.Name);
    }


    [Fact]
    public void Authenticate_ShouldReturnTrue_WhenValidCredentials()
    {
      // FIXME: Write another test for this method
      // // Arrange
      // var user = new User(
      //     1,
      //     "John",
      //     "Doe",
      //     "Doe",
      //     new DateTime(1990, 1, 1),
      //     new MailAddress("john.doe@example.com"),
      //     "password",
      //     "johndoe",
      //     UserRole.STUDENT);
      // mockUserRepository.Setup(repo => repo.GetUserByUsername(It.IsAny<string>())).Returns(user);

      // // Act
      // var result = administration.Authenticate("johndoe", "password");

      // // Assert
      // Assert.True(result);
      // Assert.Equal(user, administration.CurrentUser);
    }

    [Fact]
    public void Authenticate_ShouldReturnFalse_WhenInvalidCredentials()
    {
      // FIXME: Write another test for this method
      // // Arrange
      // mockUserRepository.Setup(repo => repo.GetUserByUsername(It.IsAny<string>())).Returns((User)null);

      // // Act
      // var result = administration.Authenticate("johndoe", "password");

      // // Assert
      // Assert.False(result);
      // Assert.Null(administration.CurrentUser);
    }
  }
}
