using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Services
{
  public interface IDashboardService
  {
    IEnumerable<LearningModule> GetCurrentLearningModules(User user);
    IEnumerable<LearningModule> GetCompletedLearningModules(User user);
    int GetCurrentLearningStreak(User user);
    int GetTotalScore(User user);
  }
}
