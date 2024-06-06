using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerShared.Helpers;
using System.Collections.ObjectModel;
namespace LingoPartnerDomain.Classes
{
  public class Administration
  {
    private readonly IAuthenticationService authenticationService;
    private readonly ILearningStreakService learningStreakService;
    private readonly ILearningModuleService learningModuleService;

    private readonly IUserRepository userRepository;
    private readonly ILearningModuleRepository learningModuleRepository;
    private readonly ILearningActivityRepository learningActivityRepository;
    private readonly IProgressRepository progressRepository;

    private List<User> users;
    public IReadOnlyList<User> Users => users;
    private List<LearningModule> learningModules;
    public IReadOnlyList<LearningModule> LearningModules => learningModuleService.GetAllLearningModules().ToList<LearningModule>();
    private List<LearningActivity> learningActivities;
    public IReadOnlyList<LearningActivity> LearningActivities => learningActivities;

    public Administration(
      IUserRepository userRepository,
      ILearningModuleRepository learningModuleRepository,
      ILearningActivityRepository learningActivityRepository,
      IProgressRepository progressRepository,
      IAuthenticationService authenticationService,
      ILearningStreakService learningStreakService,
      ILearningModuleService learningModuleService
      )
    {
      // Inject the repositories
      this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
      this.learningModuleRepository = learningModuleRepository ?? throw new ArgumentNullException(nameof(learningModuleRepository));
      this.learningActivityRepository = learningActivityRepository ?? throw new ArgumentNullException(nameof(learningActivityRepository));
      this.progressRepository = progressRepository ?? throw new ArgumentNullException(nameof(progressRepository));
      this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
      this.learningStreakService = learningStreakService ?? throw new ArgumentNullException(nameof(learningStreakService));
      this.learningModuleService = learningModuleService ?? throw new ArgumentNullException(nameof(learningModuleService));
      users = userRepository.GetUsers().ToList();
      learningModules = learningModuleRepository.GetAllLearningModules().ToList();
      learningActivities = learningActivityRepository.GetAll().ToList();
      // Get the data from the repositories
      // RetrieveAllData();
    }
    public void Add(User user)
    {
      User? result = userRepository.AddUser(user);
      if (result == null)
      {
        LoggingHelper.LogError(new Exception("User not added."), "User not added.");
        return;
      }
      // FIXME: Add to the list or not? Or should we just get the data from the repository?
      this.users = userRepository.GetUsers().ToList();
    }
    public void Add(LearningModule module)
    {
      LearningModule? result = learningModuleRepository.AddLearningModule(module);
      // Check if Result is has written to the database
      if (result == null)
      {
        LoggingHelper.LogError(new Exception("Learning module not added."), "Learning module not added.");
        return;
      }
    }
    public User? UpdateUserProfile(User updatedUser, string? newPassword)
    {
      User? user = users.Find(u => u.Id == updatedUser.Id);
      if (user != null)
      {
        // Ensure that the new password is not empty
        if (string.IsNullOrWhiteSpace(newPassword))
        {
          LoggingHelper.LogError(new ArgumentException("Password cannot be empty."), "Password cannot be empty.");
          throw new ArgumentException("Password cannot be empty.");
        }

        // Update the user's profile
        user.UpdateProfile(updatedUser.FirstName, updatedUser.MiddleName, updatedUser.LastName, updatedUser.Email, newPassword);
        userRepository.UpdateUser(user); // Ensure user is updated in the repository
        this.users = userRepository.GetUsers().ToList(); // Ensure the list is updated
        return user;
      }
      else
      {
        LoggingHelper.LogWarning("User not found.");
        return null;
      }
    }
    public void RetrieveAllData()
    {
      this.users = userRepository.GetUsers().ToList();
      // TODO: is this still needed? Because of the use of learningModuleService the data is directly returned from the service and the database
      this.learningModules = learningModuleRepository.GetAllLearningModules().ToList();
      this.learningActivities = learningActivityRepository.GetAll().ToList();
      this.progressRepository.GetAllProgress().ToList();
    }
    public LearningActivity? Add(LearningActivity newLearningActivity)
    {
      LearningModule? module = learningModules.Find(m => m.Id == newLearningActivity.LearningModuleId);
      if (module != null)
      {
        // FIXME: Why would a adding a learning activity return null?
        // 
        LearningActivity? result = learningActivityRepository.Add(newLearningActivity);
        if (result == null)
        {
          LoggingHelper.LogError(new Exception("Learning activity not added."), "Learning activity not added.");
          return null;
        }
        this.learningActivities = learningActivityRepository.GetAll().ToList();
        return result;
      }
      else
      {
        LoggingHelper.LogWarning("Learning module not found.");
        return null;
      }
    }
    public ReadOnlyCollection<Progress> GetProgressRecordsByUser(User user)
    {
      int userId = user.Id ?? throw new ArgumentNullException(nameof(user.Id));
      return progressRepository.GetProgressByUserId(userId)
                               .ToList<Progress>()
                               .AsReadOnly();
    }
    public LearningStreak? GetCurrentLearningStreak()
    {
      return learningStreakService.GetCurrentStreak();
    }
    public IEnumerable<LearningModule> GetAllLearningModules()
    {
      return learningModuleService.GetAllLearningModules();
    }
    public LearningModule? GetLearningModuleById(int id)
    {
      return learningModuleService.GetLearningModuleById(id);
    }
    public void AddLearningModule(LearningModule learningModule)
    {
      learningModuleService.AddLearningModule(learningModule);
    }
    public void UpdateLearningModule(LearningModule learningModule)
    {
      learningModuleService.UpdateLearningModule(learningModule);
    }
    public void DeleteLearningModule(int id)
    {
      learningModuleService.DeleteLearningModule(id);
    }

    // FIXME: Later on this should be removed and use the serviceprovider for injecting the authentication service when needed. 
    public User? CurrentUser => authenticationService.CurrentUser;
  }
}
