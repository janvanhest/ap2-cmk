using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Services.Strategy;

namespace LingoPartnerDomain.Interfaces.Services
{
  public interface ILearningStreakService
  {
    void Initialize(User user);
    int GetCurrentLearningStreak();
    int GetTotalScore(int userId, ILearningStreakCalculationStrategy calculator);
    IReadOnlyCollection<LearningStreak> GetStreaks();
    IEnumerable<DateTime> GetUniqueActivityDates(int userId);
    List<LearningStreak> GetLearningStreaks(int userId);
    List<LearningStreak> GetAdvancedLearningStreaks(int userId);

  }
}