using System.Diagnostics;
using LingoPartnerDomain.interfaces;
using LingoPartnerShared.Helpers;

namespace LingoPartnerDomain.classes
{
  public class Administration
  {
    private readonly IUserRepository userRepository;
    private readonly ILearningModuleRepository learningModuleRepository;
    private readonly ILearningActivityRepository learningActivityRepository;
    private readonly IProgressRepository progressRepository;

    private List<User> users;
    public IReadOnlyList<User> Users => users;
    private List<LearningModule> learningModules;
    public IReadOnlyList<LearningModule> LearningModules => learningModules;
    private List<LearningActivity> learningActivities;
    public IReadOnlyList<LearningActivity> LearningActivities => learningActivities;

    public User? CurrentUser { get; private set; }

    public Administration(
      IUserRepository userRepository,
      ILearningModuleRepository learningModuleRepository,
      ILearningActivityRepository learningActivityRepository,
      IProgressRepository progressRepository
      )
    {
      // Inject the repositories
      this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
      this.learningModuleRepository = learningModuleRepository ?? throw new ArgumentNullException(nameof(learningModuleRepository));
      this.learningActivityRepository = learningActivityRepository ?? throw new ArgumentNullException(nameof(learningActivityRepository));
      this.progressRepository = progressRepository ?? throw new ArgumentNullException(nameof(progressRepository));
      this.users = userRepository.GetUsers().ToList();
      this.learningModules = learningModuleRepository.GetAllLearningModules().ToList();
      this.learningActivities = learningActivityRepository.GetAll().ToList();
      // Get the data from the repositories
      // RetrieveAllData();
    }
    public void Add(User user)
    {
      var result = userRepository.AddUser(user);
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
      var result = learningModuleRepository.AddLearningModule(module);
      // Check if Result is has written to the database
      if (result == null)
      {
        LoggingHelper.LogError(new Exception("Learning module not added."), "Learning module not added.");
        return;
      }
      this.learningModules = learningModuleRepository.GetAllLearningModules().ToList();
    }
    public User? UpdateUserProfile(User updatedUser, string? newPassword)
    {
      var user = users.Find(u => u.Id == updatedUser.Id);
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
    public void RemoveLearningModule(int moduleId)
    {
      var module = learningModules.Find(m => m.Id == moduleId);
      if (module != null)
      {
        learningModules.Remove(module);
        // TODO: Remove learning module from the database throug a repository
        Console.WriteLine($"Learning module '{module.Name}' removed.");
      }
      else
      {
        // FIXME: Put the console output in view layer
        // retourneer iets waarom iets niet is gelukt. 
        // Console writeline weghalen. 
        // exception gooien vertraagt het programma door het opbouwen van stacktrace. 
        Console.WriteLine("Learning module not found.");
      }
    }
    public bool Authenticate(string username, string password)
    {
      User? user = userRepository.GetUserByUsername(username);
      if (user != null && user.Password == password)
      {
        CurrentUser = user;
        return true;
      }
      return false;
    }
    public void RetrieveAllData()
    {
      this.users = userRepository.GetUsers().ToList();
      this.learningModules = learningModuleRepository.GetAllLearningModules().ToList();
      this.learningActivities = learningActivityRepository.GetAll().ToList();
      this.progressRepository.GetAllProgress().ToList();
    }

    public LearningActivity? Add(LearningActivity newLearningActivity)
    {
      var module = learningModules.Find(m => m.Id == newLearningActivity.LearningModuleId);
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
    public int CalculateTotalScore(User user)
    {
      int userId = user.Id ?? throw new ArgumentNullException(nameof(user.Id));
      List<Progress> progressRecords = progressRepository.GetProgressByUserId(userId).ToList();
      var streaks = CalculateStreaks(progressRecords);

      // Choose the strategy
      IStreakCalculationStrategy strategy = new AdvancedStreakCalculationStrategy();
      StreakCalculator calculator = new StreakCalculator(strategy);

      return calculator.CalculateScore(streaks);
    }

    public LearningStreak? GetLastStreak(User user)
    {
      List<Progress> progressRecords = GetProgressRecordsByUser(user);
      List<LearningStreak> streaks = CalculateStreaks(progressRecords);
      return streaks.OrderByDescending(streak => streak.EndDate).FirstOrDefault();
    }

    public LearningStreak? GetFirstStreak(User user)
    {
      List<Progress> progressRecords = GetProgressRecordsByUser(user);
      var streaks = CalculateStreaks(progressRecords);
      return streaks.OrderBy(streak => streak.StartDate).FirstOrDefault();
    }

    public List<Progress> GetProgressRecordsByUser(User user)
    {
      int userId = user.Id ?? throw new ArgumentNullException(nameof(user.Id));
      return progressRepository.GetProgressByUserId(userId).ToList();
    }
    private List<LearningStreak> CalculateStreaks(List<Progress> progressRecords)
    {
      var streaks = new List<LearningStreak>();
      if (progressRecords == null || progressRecords.Count == 0)
        return streaks;

      progressRecords.Sort((x, y) => x.Date.CompareTo(y.Date));

      DateTime? streakStart = null;
      DateTime? streakEnd = null;

      for (int i = 0; i < progressRecords.Count; i++)
      {
        if (streakStart == null)
        {
          streakStart = progressRecords[i].Date;
          streakEnd = progressRecords[i].Date;
        }
        else
        {
          if ((progressRecords[i].Date - streakEnd.Value).Days == 1)
          {
            streakEnd = progressRecords[i].Date;
          }
          else
          {
            streaks.Add(new LearningStreak(
              progressRecords[i].UserId,
              streakStart.Value,
              streakEnd.Value,
              (streakEnd.Value - streakStart.Value).Days + 1,
              progressRecords.Count
              ));
            streakStart = progressRecords[i].Date;
            streakEnd = progressRecords[i].Date;
          }
        }
      }
      if (streakStart != null && streakEnd != null)
      {
        streaks.Add(new LearningStreak(
          progressRecords[progressRecords.Count - 1].UserId,
          streakStart.Value,
          streakEnd.Value,
          (streakEnd.Value - streakStart.Value).Days + 1,
          progressRecords.Count
          ));
      }

      return streaks;
    }
  }
}
