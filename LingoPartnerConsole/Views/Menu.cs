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
      "Show all LearningActivities", // 7
      "Show all LearningActivities for a LearningModule", // 8
      "Show all LearningActivities for a User", // 9
      "Show all LearningActivities for a Teacher", // 10
      "Show all LearningActivities for a Student", // 11
      "Show all LearningActivities for a LearningModule and a User", // 12
    };

    public Menu(Administration schoolAdministration)
    {
      SchoolAdministration = schoolAdministration;
    }
    public void Show()
    {
      Console.Clear();

      ShowMenuOptions(MenuItems);

      Console.WriteLine("Please enter your choice:\n");
      Console.WriteLine($"Enter your choice (0-{MenuItems.Count}):");

      var choice = Console.ReadLine();

      // check if the choice is an integer
      int menuIndex = ValidateMenuIndex(choice);
      Console.Clear();
      UserList userList = new UserList(SchoolAdministration);
      switch (choice)
      {
        case "0":
          GoodBey();
          break;
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
        case "7":
          LearningActivityList learningActivityList = new LearningActivityList(SchoolAdministration);
          learningActivityList.Show();
          break;
        default:
          NotImplemented(menuIndex);
          MenuHelper.ReturnToMenu(SchoolAdministration);
          break;
      }
      MenuHelper.ReturnToMenu(SchoolAdministration);
    }
    private void GoodBey()
    {
      Console.WriteLine("Goodbye!");
      Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
      Environment.Exit(0);
    }
    private int ValidateMenuIndex(string? choice)
    {
      if (int.TryParse(choice, out int result))
      {
        if (result >= 0 && result <= MenuItems.Count)
        {
          return result;
        }
      }

      Console.WriteLine("Invalid choice. Please try again.");
      return -1;
    }
    public void NotImplemented(int menuIndex)
    {
      string description = menuIndex >= 1 && menuIndex <= MenuItems.Count
          ? $"\nThis is not implemented yet\nMenu Index: {menuIndex}\nMenu Description: {MenuItems[menuIndex - 1]}\n"
          : "This feature is not implemented yet.";
      Console.WriteLine($"{description}");
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

