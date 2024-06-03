using LingoPartnerDomain.Classes;

namespace LingoPartnerConsole.View
{
  public class ConsoleLearningStreakView
  {
    private readonly Administration adminstration;

    public ConsoleLearningStreakView(Administration administration)
    {
      adminstration = administration;
    }

    public void ShowLearningStreak(string username)
    {
      var user = adminstration.CurrentUser;
      if (user == null)
      {
        Console.WriteLine("User not authenticated.");
        return;
      }

      Console.WriteLine($"User: {user.Username}");
      Console.WriteLine($"Role: {user.Role}");

      Console.WriteLine($"Current Learning Streak: {adminstration.GetCurrentLearningStreak(user)} days");
      Console.WriteLine($"Total Score: {adminstration.GetTotalScore(user)} points");
    }
  }
}
