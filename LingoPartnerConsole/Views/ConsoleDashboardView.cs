using LingoPartnerConsole.Helpers;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerInfrastructure.Services;

namespace LingoPartnerConsole.Views
{
  public class ConsoleDashboardView
  {
    private IAuthenticationService authenticationService;
    private ILearningModuleService learningModuleService;
    private IProgressService progressService;
    public ConsoleDashboardView(
        IAuthenticationService authenticationService,
        ILearningModuleService learningModuleService,
        IProgressService progressService)
    {
      this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
      this.learningModuleService = learningModuleService ?? throw new ArgumentNullException(nameof(learningModuleService));
      this.progressService = progressService ?? throw new ArgumentNullException(nameof(progressService));
    }

    public void ShowDashboard()
    {
      User? user = authenticationService.CurrentUser;
      if (user == null)
      {
        Console.WriteLine("User not found.");
        return;
      }

      ConsoleHelper.DisplayMessage("Dashboard", LingoPartnerDomain.enums.MessageType.INFORMATION);

      Console.WriteLine($"User: {user.getFullName()}");
      Console.WriteLine($"Role: {user.Role}");

      // TODO:
      Console.WriteLine("Current Learning Modules:");
      IReadOnlyCollection<LearningModule> learningModules = learningModuleService.GetByUserId((int)user.Id).ToList();
      foreach (var module in learningModules)
      {
        double percentage = progressService.GetModuleCompletionPercentage((int)module.Id);
        Console.WriteLine($"Module: {module.Name} - {percentage}% completed");

      }

      // Console.WriteLine($"Current Learning Streak: {administration.GetCurrentLearningStreak(user)} days");
      // Console.WriteLine($"Total Score: {administration.GetTotalScore(user)} points");
    }
  }
}
