using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Strategies;

namespace LingoPartnerDomain.Strategies
{
  public class ConsecutiveDaysStrategy : ILearningStreakStrategy
  {
    public List<LearningStreak> GetLearningStreaks(List<DateTime> uniqueDates, ILearningStreakScoringStrategy scoringStrategy)
    {
      // Ensure the dates are sorted
      uniqueDates.Sort();
      // Create a list to store the learning streaks
      List<LearningStreak> streaks = new List<LearningStreak>();
      // If there are no unique dates, return an empty list
      if (!uniqueDates.Any()) return streaks;
      // Initialize a current streak
      LearningStreak currentStreak = new LearningStreak(scoringStrategy);
      currentStreak.AddActivityDate(uniqueDates[0]);
      // Loop through the unique dates starting from the second date
      for (int i = 1; i < uniqueDates.Count; i++)
      {
        DateTime date = uniqueDates[i];
        DateTime previousDate = uniqueDates[i - 1];
        // Check if the current date is the next day after the previous date
        if ((date - previousDate).Days == 1)
        {
          // Add to the current streak
          currentStreak.AddActivityDate(date);
        }
        else
        {
          // Validate and add the current streak if it meets the criteria
          if (currentStreak.MeetCriteria())
          {
            streaks.Add(currentStreak);
          }
          // Start a new streak
          currentStreak = new LearningStreak(scoringStrategy);
          currentStreak.AddActivityDate(date);
        }
      }
      // Validate and add the last streak if it meets the criteria
      if (currentStreak.MeetCriteria()) streaks.Add(currentStreak);
      // Return the list of learning streaks
      return streaks;
    }
  }
}