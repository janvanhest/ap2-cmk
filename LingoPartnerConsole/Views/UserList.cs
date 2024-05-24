using LingoPartnerDomain.classes;
using LingoPartnerDomain.enums;

namespace LingoPartnerConsole.Views
{
  public class UserList
  {
    private Administration SchoolAdministration;
    public UserList(Administration schoolAdministration)
    {
      SchoolAdministration = schoolAdministration;
    }
    public void Show(UserRole? role = null)
    {
      UserRole? roleToFilter = null;
      if (role != null)
      {
        roleToFilter = role;
      }
      foreach (User user in SchoolAdministration.Users)
      {
        if (roleToFilter == null || user.Role == roleToFilter)
        {
          Console.WriteLine($"{user.Id}. {user.FirstName} {user.MiddleName} {user.LastName} ({user.Role})");
        }
      }
    }
  }
}