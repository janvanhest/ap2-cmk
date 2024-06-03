using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Services
{
  public interface ILearningStreakService
  {
    int GetCurrentLearningStreak(User user);
    int GetTotalScore(User user);
  }
}