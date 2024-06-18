using LingoPartnerDomain.Classes;
namespace LingoPartnerDomain.Interfaces.Strategies
{
  public interface ILearningStreakScoringStrategy
  {
    int CalculateScore(LearningStreak streak);
  }
}