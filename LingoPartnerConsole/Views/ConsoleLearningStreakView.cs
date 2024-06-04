using LingoPartnerDomain.Classes;

namespace LingoPartnerConsole.View
{
  public class ConsoleLearningStreakView
  {
    private readonly Administration administration;

    public ConsoleLearningStreakView(Administration administration)
    {
      this.administration = administration;
    }

    public void ShowLearningStreak()
    {
      var user = administration.CurrentUser;
      if (user == null)
      {
        Console.WriteLine("User not authenticated.");
        return;
      }

      Console.WriteLine($"User: {user.Username}");
      Console.WriteLine($"Role: {user.Role}");

      Console.WriteLine($"Current Learning Streak: {administration.GetCurrentLearningStreak()} days");
      Console.WriteLine($"Total Score: {administration.GetTotalScore()} points");

      var streaks = administration.GetStreaks().ToList<LearningStreak>();
      Console.WriteLine("All Streaks:");
      foreach (var streak in streaks)
      {
        Console.WriteLine($"Streak Length: {streak.GetLength()} days");
      }
    }
  }
}
