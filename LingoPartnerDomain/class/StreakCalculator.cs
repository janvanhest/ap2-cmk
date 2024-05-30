using LingoPartnerDomain.interfaces;

namespace LingoPartnerDomain.classes
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