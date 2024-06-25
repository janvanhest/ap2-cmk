using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Strategies;

namespace LingoPartnerDomain.Strategies.Scoring
{
  public class SimpleScoringStrategy : ILearningStreakScoringStrategy
  {
    public int CalculateScore(LearningStreak streak)
    {
      return streak.Length; // Example: 1 point per day
    }
  }
}