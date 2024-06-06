using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces.Services
{
  public interface ILearningStreakService
  {
    List<LearningStreak> GetLearningStreaks();
    int CalculateTotalScore();
    LearningStreak? GetCurrentStreak();
  }
}