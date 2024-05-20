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
      "Show all LearningModules", // 6
    };

    public Menu(Administration schoolAdministration)
    {
      SchoolAdministration = schoolAdministration;
    }
    public void Show()
    {
      // Two carriage returns
      Console.Clear();
      ShowMenuOptions(MenuItems);

      Console.WriteLine("Please enter your choice:\n");
      string? choice = Console.ReadLine();
      Console.Clear();
      UserList userList = new UserList(SchoolAdministration);
      switch (choice)
      {
        case "1":
          UserAdd userAdd = new UserAdd(SchoolAdministration);
          userAdd.Show();
          break;
        case "2":
          userList.Show();
          break;
        case "3":
          userList.Show("Teacher");
          break;
        case "4":
          userList.Show("Student");
          break;
        case "5":
          LearningModuleAdd learningModuleAdd = new LearningModuleAdd(SchoolAdministration);
          learningModuleAdd.Show();
          break;
        case "6":
          LearningModuleList learningModuleList = new LearningModuleList(SchoolAdministration);
          learningModuleList.Show();
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
      Console.WriteLine("0. Exit\n");
    }
  }
}

