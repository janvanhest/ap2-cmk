using LingoPartnerDomain.classes;

namespace LingoPartnerConsole.Views
{
  internal class Menu
  {
    public Administration SchoolAdministration;
    public List<string> MenuItems = new List<string>
    {
      "Add a user", // 1
      "Show all users", // 2
      "Show all teachers", // 3
      "Show all students", // 4
      "Exit" // 11
    };
    public Menu(Administration schoolAdministration)
    {
      SchoolAdministration = schoolAdministration;
    }
    public void Show()
    {
      // Two carriage returns
      Console.Clear();
      Console.WriteLine("\n\n");
      Console.WriteLine("Welcome to the LingoPartner Console Application");
      Console.WriteLine("1. Add a user");
      Console.WriteLine("2. Show all users");
      Console.WriteLine("3. Show all teachers");
      Console.WriteLine("4. Show all students");

      // Console.WriteLine("11. Exit");

      Console.WriteLine("Please enter your choice:");
      string? choice = Console.ReadLine();
      switch (choice)
      {
        // add a user
        case "1":
          UserAdd userAdd = new UserAdd(SchoolAdministration);
          userAdd.Show();
          break;
        // show all users
        case "2":
          UserList userList = new UserList(SchoolAdministration);
          userList.Show();
          break;
        case "4":
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("Invalid choice, option does not exist. Please try again.");
          break;
      }
      Console.ReadKey();
      MenuHelper.ReturnToMenu(SchoolAdministration);
    }
  }
}

