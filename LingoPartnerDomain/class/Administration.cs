using LingoPartnerInfrastructure;
using LingoPartnerDomain.Helpers.ObjectMappers;
using LingoPartnerInfrastructure.DTO;

namespace LingoPartnerDomain.classes
{
  public class Administration
  {
    private List<User> Users = new List<User>();
    public IReadOnlyList<User> users
    { get { return this.Users; } }
    private List<LearningModule> LearningModules = new List<LearningModule>();
    public IReadOnlyList<LearningModule> learningModules
    { get { return this.LearningModules; } }
    public Administration()
    {
      // Users = new List<User>();
      // LearningModules = new List<LearningModule>();
      UserRepository userRepository = new UserRepository();
      List<UserDTO> userDTOs = userRepository.GetUsers();
      foreach (UserDTO userDTO in userDTOs)
      {
        User user = userDTO.ToDomain();
        Users.Add(user);
      }

    }
    public void Add(User user)
    {
      // Users.Add(user);
      // FIXME: implement correct logging. Only loggin in views
      new UserRepository().AddUser(user.ToDTO());
      Console.WriteLine($"User {user.FirstName} {user.LastName} added.");

    }
    public void Add(LearningModule module)
    {
      // LearningModules.Add(module);
      // new LearningModuleRepository().AddLearningModule(module.ToDTO());
      // Console.WriteLine($"Learning module '{module.Name}' added.");
    }
    public void UpdateUserProfile(User updatedUser, string? newPassword)
    {
      var user = Users.Find(u => u.Id == updatedUser.Id);
      if (user != null)
      {
        user.UpdateProfile(updatedUser.FirstName, updatedUser.MiddleName, updatedUser.LastName, updatedUser.Email, newPassword ?? string.Empty);
        Console.WriteLine($"JHE: User {updatedUser.FirstName} {updatedUser.LastName} updated.");
      }
      else
      {
        // TODO: Log error Or create domain exception
        Console.WriteLine("User not found.");
      }
    }
    public void RemoveLearningModule(int moduleId)
    {
      var module = LearningModules.Find(m => m.Id == moduleId);
      if (module != null)
      {
        LearningModules.Remove(module);
        Console.WriteLine($"Learning module '{module.Name}' removed.");
      }
      else
      {
        Console.WriteLine("Learning module not found.");
      }
    }
  }
}
