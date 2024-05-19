using LingoPartnerDomain.classes;

namespace LingoPartnerConsole.Views
{
  internal class Menu
  {
    public Administration SchoolAdministration;
    private List<string> MenuItems = new List<string>
    {
      "Add a user", // 1
      "Show all users", // 2
      "Show all teachers", // 3
      "Show all students", // 4
      "Add a LearningModule", // 5
    };

    public Menu(Administration schoolAdministration)
    {
      SchoolAdministration = schoolAdministration;
    }
    public void Show()
    {
      // Two carriage returns
      Console.Clear();
      // Console.WriteLine("\n\n");
      // Console.WriteLine("Welcome to the LingoPartner Console Application");
      // Console.WriteLine("1. Add a user");
      // Console.WriteLine("2. Show all users");
      // Console.WriteLine("3. Show all teachers");
      // Console.WriteLine("4. Show all students");
      // Console.WriteLine("0. Exit");
      ShowMenuOptions(MenuItems);

      Console.WriteLine("Please enter your choice:");
      string? choice = Console.ReadLine();
      switch (choice)
      {
        case "1":
          UserAdd userAdd = new UserAdd(SchoolAdministration);
          userAdd.Show();
          break;
        case "2":
          UserList userList = new UserList(SchoolAdministration);
          userList.Show();
          break;
        case "3":
          NotImplemented();
          break;
        case "4":
          NotImplemented();
          break;
        case "5":
          LearningModuleAdd learningModuleAdd = new LearningModuleAdd(SchoolAdministration);
          learningModuleAdd.Show();
          break;
        case "0":
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("Invalid choice");
          Show();
          break;
      }
      MenuHelper.ReturnToMenu(SchoolAdministration);
    }
    public void NotImplemented()
    {
      Console.WriteLine("Not implemented yet.");
    }

    public void ShowMenuOptions(List<string> menuItems)
    {
      Console.WriteLine("Please select on of the following options:");
      int index = 1;
      foreach (string item in menuItems)
      {
        Console.WriteLine($"{index}. {item}");
        index++;
      }
      Console.WriteLine("0. Exit");
    }
  }
}

