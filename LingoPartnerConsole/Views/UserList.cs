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
    public void Show(string? role = null)
    {
      Console.WriteLine(role == null ? "List of all users:\n" : $"List of all {role}s:\n");

      UserRole? roleToFilter = null;
      if (!string.IsNullOrEmpty(role))
      {
        if (Enum.TryParse(typeof(UserRole), role, true, out var result))
        {
          roleToFilter = (UserRole)result;
        }
        else
        {
          Console.WriteLine("Invalid role specified.");
          return;
        }
      }
      int index = 1;
      foreach (User user in SchoolAdministration.Users)
      {
        if (roleToFilter == null || user.Role == roleToFilter)
        {
          Console.WriteLine($"{index++}. {user.FirstName} {user.MiddleName} {user.LastName} ({user.Role})");
        }
      }
    }
  }
}