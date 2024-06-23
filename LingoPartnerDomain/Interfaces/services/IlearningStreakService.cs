using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Strategies;

namespace LingoPartnerDomain.Interfaces.Services
{
  public interface ILearningStreakService
  {
    void SetLearningStreakStrategy(ILearningStreakStrategy learningStreakStrategy);
    List<LearningStreak> GetLearningStreaks();
    int CalculateTotalScore(ILearningStreakScoringStrategy? scoringStrategy);
    LearningStreak? GetCurrentStreak();
  }
}