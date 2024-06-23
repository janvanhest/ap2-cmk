using LingoPartnerConsole.Helpers;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerDomain.Strategies;
using LingoPartnerDomain.Strategies.Scoring;

namespace LingoPartnerConsole.Views
{
  public class ConsoleDashboardView
  {
    private readonly ILearningStreakService learningStreakService;
    private readonly ILearningModuleService learningModuleService;
    private readonly IProgressService progressService;

    public ConsoleDashboardView(
        ILearningStreakService learningStreakService,
        ILearningModuleService learningModuleService,
        IProgressService progressService)
    {
      this.learningModuleService = learningModuleService ?? throw new ArgumentNullException(nameof(learningModuleService));
      this.progressService = progressService ?? throw new ArgumentNullException(nameof(progressService));
      this.learningStreakService = learningStreakService ?? throw new ArgumentNullException(nameof(learningStreakService));
    }

    public void ShowDashboard(User currentUser)
    {
      if (currentUser == null)
      {
        Console.WriteLine("User not found, no dashboard to show.");
        return;
      }

      int userId = currentUser.Id ?? throw new ArgumentNullException(nameof(currentUser.Id));
      ConsoleHelper.DisplayMessage("Dashboard", MessageType.INFORMATION);

      Console.WriteLine($"User: {currentUser.GetFullName()}");
      Console.WriteLine($"Role: {currentUser.Role}");

      // TODO: Handle potential issues when user has no learning modules
      IReadOnlyCollection<LearningModule> learningModules = learningModuleService.GetByUserId(userId).ToList();

      ConsoleHelper.DisplayMessage("Current Learning Modules:", MessageType.INFORMATION);
      foreach (var module in learningModules)
      {
        double percentage = progressService.GetModuleCompletionPercentage((int)module.Id, currentUser);
        Console.WriteLine($"Module: {module.Name} - {percentage}% completed");
        ConsoleHelper.DisplayProgressBar(percentage);
      }

      bool validChoice = false;
      while (!validChoice)
      {
        Console.WriteLine("Exclude weekends in streak calculation? Y/N\n");
        ConsoleKeyInfo choice = Console.ReadKey();
        Console.WriteLine(); // Move to the next line after reading the key
        if (choice.Key == ConsoleKey.Y)
        {
          learningStreakService.SetLearningStreakStrategy(new ConsecutiveDaysStrategy());
          validChoice = true;
        }
        else if (choice.Key == ConsoleKey.N)
        {
          learningStreakService.SetLearningStreakStrategy(new WeekendSkipStrategy());
          validChoice = true;
        }
        else
        {
          Console.WriteLine("Invalid choice. Please enter 'Y' or 'N'.");
        }
      }
      Console.WriteLine();
      ConsoleHelper.DisplayMessage("Here comes the Streak", MessageType.INFORMATION);
      int simpleScore = learningStreakService.CalculateTotalScore(new SimpleScoringStrategy());
      int bonusScore = learningStreakService.CalculateTotalScore(new BonusScoringStrategy());
      Console.WriteLine($"Simple Score: \nThe learning streak score takes {simpleScore} days into account");
      Console.WriteLine($"Bonus Score: \n{bonusScore}");
    }
  }
}
