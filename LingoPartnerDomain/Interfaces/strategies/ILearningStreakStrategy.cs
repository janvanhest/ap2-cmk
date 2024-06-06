using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces.Strategies
{
  public interface ILearningStreakStrategy
  {
    List<LearningStreak> GetLearningStreaks(List<DateTime> uniqueDates);
  }
}
