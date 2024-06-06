using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Strategies;

namespace LingoPartnerDomain.Strategies
{
  public class WeekendSkipStrategy : ILearningStreakStrategy
  {
    public List<LearningStreak> GetLearningStreaks(List<DateTime> uniqueDates)
    {
      List<LearningStreak> streaks = new List<LearningStreak>();

      if (!uniqueDates.Any()) return streaks;

      LearningStreak? currentStreak = null;

      for (int i = 0; i < uniqueDates.Count; i++)
      {
        DateTime date = uniqueDates[i];

        if (currentStreak == null)
        {
          // Create a new streak if there is no current streak
          currentStreak = new LearningStreak();
          currentStreak.AddActivityDate(date);
          streaks.Add(currentStreak);
        }
        else
        {
          DateTime previousDate = uniqueDates[i - 1];
          bool isNextDay = (date - previousDate).Days == 1;
          bool isWeekendSkip = previousDate.DayOfWeek == DayOfWeek.Friday && date.DayOfWeek == DayOfWeek.Sunday;

          if (isNextDay || isWeekendSkip)
          {
            currentStreak.AddActivityDate(date);
          }
          else
          {
            currentStreak = new LearningStreak();
            currentStreak.AddActivityDate(date);
            streaks.Add(currentStreak);
          }
        }
      }

      return streaks;
    }
  }
}