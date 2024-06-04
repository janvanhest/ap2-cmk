using LingoPartnerDomain.Interfaces.Services.Strategy;
namespace LingoPartnerDomain.Classes
{
  public class BasicStreakCalculationStrategy : ILearningStreakCalculationStrategy
  {
    public int CalculateScore(List<LearningStreak> streaks)
    {
      int totalScore = 0;
      foreach (LearningStreak streak in streaks)
      {
        totalScore += streak.GetLength(); // Each day in the streak is a point
      }
      return totalScore;
    }
  }
}