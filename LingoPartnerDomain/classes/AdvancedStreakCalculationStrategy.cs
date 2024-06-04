﻿using LingoPartnerDomain.Interfaces.Services.Strategy;

namespace LingoPartnerDomain.Classes
{
  public class AdvancedStreakCalculationStrategy : ILearningStreakCalculationStrategy
  {
    public int CalculateScore(List<LearningStreak> streaks)
    {
      int totalScore = 0;
      foreach (var streak in streaks)
      {
        int daysInStreak = streak.GetLength();
        totalScore += daysInStreak;

        DateTime currentDate = streak.getFirstDay();
        int daysInWeek = 0;
        while (currentDate <= streak.getLastDay())
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
}