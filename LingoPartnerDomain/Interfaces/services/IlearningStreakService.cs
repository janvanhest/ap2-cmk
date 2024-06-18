using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Strategies;

namespace LingoPartnerDomain.Interfaces.Services
{
  public interface ILearningStreakService
  {
    List<LearningStreak> GetLearningStreaks();
    int CalculateTotalScore(ILearningStreakScoringStrategy? scoringStrategy);
    LearningStreak? GetCurrentStreak();
  }
}