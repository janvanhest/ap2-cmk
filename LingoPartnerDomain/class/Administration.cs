using System.Diagnostics;
using LingoPartnerDomain.interfaces;
using LingoPartnerDomain.Interfaces;
using LingoPartnerShared.Helpers;

namespace LingoPartnerDomain.classes
{
  public class Administration
  {
    private readonly IUserRepository userRepository;
    private readonly ILearningModuleRepository learningModuleRepository;
    private readonly ILearningActivityRepository learningActivityRepository;

    private readonly List<User> users;
    public IReadOnlyList<User> Users => users;
    private readonly List<LearningModule> learningModules;
    public IReadOnlyList<LearningModule> LearningModules => learningModules;
    private readonly List<LearningActivity> learningActivities;
    public IReadOnlyList<LearningActivity> LearningActivities => learningActivities;

    public Administration(
      IUserRepository userRepository,
      ILearningModuleRepository learningModuleRepository,
      ILearningActivityRepository learningActivityRepository)
    {
      this.userRepository = userRepository;
      this.learningModuleRepository = learningModuleRepository;
      this.learningActivityRepository = learningActivityRepository;

      this.learningModules = learningModuleRepository.GetAllLearningModules().ToList();
      this.users = userRepository.GetUsers().ToList();
      this.learningActivities = learningActivityRepository.GetAllLearningActivities().ToList();
    }
    public void Add(User user)
    {
      var result = userRepository.AddUser(user);
      if (result == null)
      {
        LoggingHelper.LogError(new Exception("User not added."), "User not added.");
        return;
      }
      users.Add(user);
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
      learningModules.Add(module);
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
        Console.WriteLine("Learning module not found.");
      }
    }
  }
}
