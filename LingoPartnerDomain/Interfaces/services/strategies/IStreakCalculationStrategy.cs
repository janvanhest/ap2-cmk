
using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces.Services.Strategy
{
  public interface ILearningStreakCalculationStrategy
  {
    int CalculateScore(List<LearningStreak> streaks);
  }
}
