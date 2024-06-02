using LingoPartnerDomain.Interfaces;

namespace LingoPartnerDomain.Classes
{
  public class StreakCalculator
  {
    private readonly IStreakCalculationStrategy _strategy;

    public StreakCalculator(IStreakCalculationStrategy strategy)
    {
      _strategy = strategy;
    }

    public int CalculateScore(List<LearningStreak> streaks)
    {
      return _strategy.CalculateScore(streaks);
    }
  }

}