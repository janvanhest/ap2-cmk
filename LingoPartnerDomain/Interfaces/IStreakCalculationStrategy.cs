using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces
{
  public interface IStreakCalculationStrategy
  {
    int CalculateScore(List<LearningStreak> streaks);
  }
}