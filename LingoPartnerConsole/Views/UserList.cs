using System.Collections.ObjectModel;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerConsole.Views
{
  public class UserList
  {
    private IUserService userService;
    public UserList(IUserService userService)
    {
      this.userService = userService;
    }
    public void Show(UserRole? role = null)
    {
      ReadOnlyCollection<User> users = userService.GetAllUsers().ToList<User>().AsReadOnly();
      UserRole? roleToFilter = null;
      if (role != null)
      {
        roleToFilter = role;
      }
      foreach (User user in users)
      {
        if (roleToFilter == null || user.Role == roleToFilter)
        {
          Console.WriteLine($"{user.Id}. {user.FirstName} {user.MiddleName} {user.LastName} ({user.Role})");
        }
      }
    }
  }
}