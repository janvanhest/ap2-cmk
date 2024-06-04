using LingoPartnerConsole.Helpers;
using LingoPartnerDomain.Classes;

namespace LingoPartnerConsole.Views
{
  public class ConsoleDashboardView
  {
    private readonly Administration administration;

    public ConsoleDashboardView(Administration administration)
    {
      this.administration = administration;
    }

    public void ShowDashboard()
    {
      User user = administration.CurrentUser;
      if (user == null)
      {
        Console.WriteLine("User not found.");
        return;
      }

      ConsoleHelper.DisplayMessage("Dashboard", LingoPartnerDomain.enums.MessageType.INFORMATION);

      Console.WriteLine($"User: {user.getFullName()}");
      Console.WriteLine($"Role: {user.Role}");

      // TODO:
      // Console.WriteLine("Current Learning Modules:");
      // foreach (var module in administration.GetCurrentLearningModules(user))
      // {
      //   Console.WriteLine(module.Name);
      // }

      // Console.WriteLine("Completed Learning Modules:");
      // foreach (var module in administration.GetCompletedLearningModules(user))
      // {
      //   Console.WriteLine(module.Name);
      // }

      // Console.WriteLine($"Current Learning Streak: {administration.GetCurrentLearningStreak(user)} days");
      // Console.WriteLine($"Total Score: {administration.GetTotalScore(user)} points");
    }
  }
}
