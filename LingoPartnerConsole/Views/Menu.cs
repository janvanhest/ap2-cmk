using LingoPartnerConsole.Helpers;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerDomain.Strategies.Scoring;

namespace LingoPartnerConsole.Views
{
  internal class Menu
  {
    private ILearningStreakService learningStreakService;
    private ILearningModuleService learningModuleService;
    private IAuthenticationService authenticationService;
    private IUserService userService;
    private ILearningActivityService learningActivityService;

    private IReadOnlyList<string> MenuItems =
    [
      "Create a User", // 1
      "Show all users", // 2
      "Show all teachers", // 3
      "Show all students", // 4
      "Update a user", // 5
      "Add a LearningModule", // 6
      "Show all LearningModules", // 7
      "Show all LearningActivities", // 8
      "Add a LearningActivity", // 9
      "Show all LearningActivities for a LearningModule", // 10
      "Show all LearningActivities for a User", // 11
      "Show all LearningActivities for a Teacher", // 12
      "Show all LearningActivities for a Student", // 13
      "Show all LearningActivities for a LearningModule and a User", // 14
      "Show my dashboard baby" // 15
    ];

    public Menu(
      ILearningStreakService learningStreakService,
      ILearningModuleService learningModuleService,
      IAuthenticationService authenticationService,
      IUserService userService,
      ILearningActivityService learningActivityService
      )
    {
      this.learningStreakService = learningStreakService ??
        throw new ArgumentNullException(nameof(learningStreakService));
      this.learningModuleService = learningModuleService ??
        throw new ArgumentNullException(nameof(learningModuleService));
      this.authenticationService = authenticationService ??
        throw new ArgumentNullException(nameof(authenticationService));
      this.userService = userService ??
        throw new ArgumentNullException(nameof(userService));
      this.learningActivityService = learningActivityService ??
        throw new ArgumentNullException(nameof(learningActivityService));
    }
    public void Show()
    {
      Console.Clear();

      ShowMenuOptions([.. MenuItems]);

      Console.WriteLine("Please enter your choice:\n");
      Console.WriteLine($"Enter your choice (0-{MenuItems.Count}):");

      string? choice = Console.ReadLine();

      // check if the choice is an integer
      int menuIndex = ValidateMenuIndex(choice);
      Console.Clear();
      UserList userList = new(userService);
      LearningModuleAdd learningModuleAdd = new(learningModuleService);
      LearningModuleList learningModuleList = new(learningModuleService);
      LearningActivityList learningActivityList = new(learningActivityService);
      LearningActivityAdd learningActivityAdd = new(learningActivityService);
      UserUpdate userUpdate = new(userService);
      UserAdd userAdd = new(userService);
      switch (choice)
      {
        case "0":
          GoodBye();
          break;
        case "1":
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
          ConsoleHelper.DisplayMessage("Update a user:");
          userList.Show();
          userUpdate.Show();
          break;
        case "6":
          ConsoleHelper.DisplayMessage("Add a new learning module");
          learningModuleAdd.Show();
          break;
        case "7":
          ConsoleHelper.DisplayMessage("List of all LearningModules:");
          learningModuleList.Show();
          break;
        case "8":
          ConsoleHelper.DisplayMessage("List of all LearningActivities:");
          learningActivityList.Show();
          break;
        case "9":
          ConsoleHelper.DisplayMessage("Add a new LearningActivity:");
          learningModuleList.Show();
          int learningModuleId = ConsoleHelper.GetIntInput("Enter the LearningModule ID:");
          learningActivityAdd.Show(learningModuleId);
          break;
        case "10":
          NotImplemented(menuIndex);
          break;
        case "15":
          ConsoleDashboardView consoleDashboardView = new(authenticationService);
          consoleDashboardView.ShowDashboard();
          ConsoleHelper.DisplayMessage("Here comes the Streak", MessageType.INFORMATION);
          // simplescoringstrategy
          int simpleScore = learningStreakService.CalculateTotalScore(new SimpleScoringStrategy());
          int BonusScoringStrategy = learningStreakService.CalculateTotalScore(new BonusScoringStrategy());
          Console.WriteLine($"Simple Score: {simpleScore}");
          Console.WriteLine($"Bonus Score: {BonusScoringStrategy}");
          break;
        default:
          NotImplemented(menuIndex);
          MenuHelper.ReturnToMenu(
              learningStreakService,
              learningModuleService,
              authenticationService,
              userService,
              learningActivityService
              );

          break;
      }
      MenuHelper.ReturnToMenu(
                    learningStreakService,
                    learningModuleService,
                    authenticationService,
                    userService,
                    learningActivityService
                    );
    }
    private void GoodBye()
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

