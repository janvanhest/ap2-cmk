using LingoPartnerConsole.Helpers;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerDomain.Strategies.Scoring;

namespace LingoPartnerConsole.Views
{
  public class ConsoleDashboardView
  {
    private ILearningStreakService learningStreakService;
    private ILearningModuleService learningModuleService;
    private IProgressService progressService;
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
      User? user = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
      int userId = user.Id ?? throw new ArgumentNullException(nameof(user.Id));
      ConsoleHelper.DisplayMessage("Dashboard", LingoPartnerDomain.enums.MessageType.INFORMATION);

      Console.WriteLine($"User: {user.getFullName()}");
      Console.WriteLine($"Role: {user.Role}");

      // TODO:
      Console.WriteLine("Current Learning Modules:");
      IReadOnlyCollection<LearningModule> learningModules = learningModuleService.GetByUserId(userId).ToList();
      foreach (var module in learningModules)
      {
        if (module.Id == null) continue;
        if (module.Name == null) continue;
        double percentage = progressService.GetModuleCompletionPercentage((int)module.Id, currentUser);
        Console.WriteLine($"Module: {module.Name} - {percentage}% completed");
        ConsoleHelper.DisplayMessage("Here comes the Streak", MessageType.INFORMATION);
        int simpleScore = learningStreakService.CalculateTotalScore(new SimpleScoringStrategy());
        int BonusScoringStrategy = learningStreakService.CalculateTotalScore(new BonusScoringStrategy());
        Console.WriteLine($"Simple Score: \nThe learning streak score takes {simpleScore} lasts days into account");
        Console.WriteLine($"Bonus Score: \n{BonusScoringStrategy}");
      }
    }
  }
}
