using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Strategies;
namespace LingoPartnerDomain.Strategies.Scoring
{
  public class BonusScoringStrategy : ILearningStreakScoringStrategy
  {
    public int CalculateScore(LearningStreak streak)
    {
      // Example: 2 points per day plus 5 bonus points for streaks longer than 5 days
      return streak.Length > 5 ? (streak.Length * 2) + 5 : streak.Length * 2;
    }
  }
}