using LingoPartnerDomain.classes;

namespace LingoPartnerDomain.interfaces
{
  public interface IStreakCalculationStrategy
  {
    int CalculateScore(List<LearningStreak> streaks);
  }
}