using LingoPartnerConsole.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.classes;

namespace LingoPartnerConsole.Views
{
  public class UserList
  {
    private Administration SchoolAdministration;
    public UserList(Administration schoolAdministration)
    {
      SchoolAdministration = schoolAdministration;
    }
    public void Show()
    {
      Console.WriteLine("List of all users");
      foreach (User user in SchoolAdministration.users)
      {
        Console.WriteLine($"{user.FirstName} {user.MiddleName} {user.LastName} ({user.Role})");
      }
    }
  }
}