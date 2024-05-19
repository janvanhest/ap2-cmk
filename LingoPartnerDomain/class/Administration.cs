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
    private List<User> users = new List<User>();
    public IReadOnlyList<User> Users
    {
      get { return this.users; }
    }
    private List<LearningModule> learningModules = new List<LearningModule>();
    public IReadOnlyList<LearningModule> LearningModules
    {
      get { return this.learningModules; }
    }
    public Administration(IUserRepository userRepository, ILearningModuleRepository learningModuleRepository)
    {
      this.userRepository = userRepository;
      this.learningModuleRepository = learningModuleRepository;

      this.learningModules = (List<LearningModule>)learningModuleRepository.GetAllLearningModules();
      this.users = userRepository.GetUsers();
    }
    public void Add(User user)
    {
      users.Add(user);
      User Result = userRepository.AddUser(user);
      // Check if Result is has written to the database
      if (Result == null)
      {
        Trace.TraceError("User not added.");
        return;
      }
    }
    public void Add(LearningModule module)
    {
      learningModules.Add(module);
      LearningModule Result = learningModuleRepository.AddLearningModule(module);
      // Check if Result is has written to the database
      if (Result == null)
      {
        Trace.TraceError("Learning module not added.");
        return;
      }
    }
    public User? UpdateUserProfile(User updatedUser, string? newPassword)
    {
      var user = users.Find(u => u.Id == updatedUser.Id);
      if (user != null)
      {
        // Ensure that the new password is not empty
        if (string.IsNullOrWhiteSpace(newPassword))
        {

          LoggingHelper
          .LogError(new ArgumentException("Password cannot be empty."), "Password cannot be empty.");
          throw new ArgumentException("Password cannot be empty.");
        }

        // Update the user's profile
        user.UpdateProfile(updatedUser.FirstName, updatedUser.MiddleName, updatedUser.LastName, updatedUser.Email, newPassword);
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
