using LingoPartnerDomain.Interfaces;

namespace LingoPartnerDomain.Classes
{
  public class BasicStreakCalculationStrategy : IStreakCalculationStrategy
  {
    public int CalculateScore(List<LearningStreak> streaks)
    {
      int totalScore = 0;
      foreach (var streak in streaks)
      {
        totalScore += streak.Length; // Each day in the streak is a point
      }
      return totalScore;
    }
  }
}