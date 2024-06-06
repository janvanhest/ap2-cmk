using LingoPartnerConsole.Helpers;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerConsole.Views
{
  internal class Menu
  {
    public Administration schoolAdministration;
    public ILearningStreakService learningStreakService;
    private IReadOnlyList<string> MenuItems = new List<string>
    {
      "Create a User", // 1
      "Show all users", // 2
      "Show all teachers", // 3
      "Show all students", // 4
      "Add a LearningModule", // 5
      "Show all LearningModules", // 6
      "Show all LearningActivities", // 7
      "Add a LearningActivity", // 8
      "Show all LearningActivities for a LearningModule", // 9
      "Show all LearningActivities for a User", // 10
      "Show all LearningActivities for a Teacher", // 11
      "Show all LearningActivities for a Student", // 12
      "Show all LearningActivities for a LearningModule and a User", // 13
      "Show my dashboard baby" // 14
    };

    public Menu(Administration schoolAdministration, ILearningStreakService learningStreakService)
    {
      this.schoolAdministration = schoolAdministration ?? throw new ArgumentNullException(nameof(schoolAdministration));
      this.learningStreakService = learningStreakService ?? throw new ArgumentNullException(nameof(learningStreakService));
    }
    public void Show()
    {
      Console.Clear();

      ShowMenuOptions([.. MenuItems]);

      Console.WriteLine("Please enter your choice:\n");
      Console.WriteLine($"Enter your choice (0-{MenuItems.Count}):");

      var choice = Console.ReadLine();

      // check if the choice is an integer
      int menuIndex = ValidateMenuIndex(choice);
      Console.Clear();
      UserList userList = new UserList(schoolAdministration);
      LearningModuleAdd learningModuleAdd = new LearningModuleAdd(schoolAdministration);
      LearningModuleList learningModuleList = new LearningModuleList(schoolAdministration);
      LearningActivityList learningActivityList = new LearningActivityList(schoolAdministration);
      LearningActivityAdd learningActivityAdd = new LearningActivityAdd(schoolAdministration);
      switch (choice)
      {
        case "0":
          GoodBey();
          break;
        case "1":
          UserAdd userAdd = new UserAdd(schoolAdministration);
          userAdd.Show();
          break;
        case "2":
          ConsoleHelper.DisplayMessage("List of all users:");
          userList.Show();
          break;
        case "3":
          ConsoleHelper.DisplayMessage("List of all teachers:");
          userList.Show(UserRole.TEACHER);
          break;
        case "4":
          ConsoleHelper.DisplayMessage("List of all students:");
          userList.Show(UserRole.STUDENT);
          break;
        case "5":
          ConsoleHelper.DisplayMessage("Add a new learning module");
          learningModuleAdd.Show();
          break;
        case "6":
          ConsoleHelper.DisplayMessage("List of all LearningModules:");
          learningModuleList.Show();
          break;
        case "7":
          ConsoleHelper.DisplayMessage("List of all LearningActivities:");
          learningActivityList.Show();
          break;
        case "8":
          ConsoleHelper.DisplayMessage("Add a new LearningActivity:");
          learningModuleList.Show();
          int learningModuleId = ConsoleHelper.GetIntInput("Enter the LearningModule ID:");
          learningActivityAdd.Show(learningModuleId);
          break;
        case "9":
          NotImplemented(menuIndex);
          break;
        case "14":
          ConsoleDashboardView consoleDashboardView = new(schoolAdministration);
          consoleDashboardView.ShowDashboard();
          ConsoleHelper.DisplayMessage("Here comes the Streak", MessageType.INFORMATION);
          Console.WriteLine(learningStreakService.CalculateTotalScore());
          break;
        default:
          NotImplemented(menuIndex);
          MenuHelper.ReturnToMenu(schoolAdministration, learningStreakService);
          break;
      }
      MenuHelper.ReturnToMenu(schoolAdministration, learningStreakService);
    }
    private void GoodBey()
    {
      ConsoleHelper.DisplayMessage("Goodbye!", MessageType.INFORMATION);
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
      ConsoleHelper.DisplayMessage("Welcome to the LingoPartner menu.", MessageType.INFORMATION);
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

