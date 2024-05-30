using LingoPartnerDomain.classes;
using LingoPartnerDomain.interfaces;

namespace LingoPartnerDomain;
public class AdvancedStreakCalculationStrategy : IStreakCalculationStrategy
{
  public int CalculateScore(List<LearningStreak> streaks)
  {
    int totalScore = 0;
    foreach (var streak in streaks)
    {
      int daysInStreak = streak.Length;
      totalScore += daysInStreak;

      DateTime currentDate = streak.StartDate;
      int daysInWeek = 0;
      while (currentDate <= streak.EndDate)
      {
        if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
        {
          daysInWeek++;
          if (daysInWeek == 3)
          {
            totalScore += 2; // Bonus for the third consecutive day
          }
        }

        if (currentDate.DayOfWeek == DayOfWeek.Sunday)
        {
          if (daysInWeek >= 5)
          {
            totalScore += 5; // Weekly bonus
          }
          daysInWeek = 0;
        }

        currentDate = currentDate.AddDays(1);
      }

      // Check for incomplete week at the end of the streak
      if (daysInWeek >= 5)
      {
        totalScore += 5; // Weekly bonus
      }
    }
    return totalScore;
  }
}
