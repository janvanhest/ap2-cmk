using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerDomain.Interfaces.Services.Strategy;

namespace LingoPartnerInfrastructure.Services
{
  public class LearningStreakService : ILearningStreakService
  {
    private readonly IProgressRepository progressRepository;

    public LearningStreakService(IProgressRepository progressRepository)
    {
      this.progressRepository = progressRepository;
    }

    public List<LearningStreak> GetAdvancedLearningStreaks(int userId)
    {
      throw new NotImplementedException();
    }

    public int GetCurrentLearningStreak()
    {
      throw new NotImplementedException();
    }

    public List<LearningStreak> GetLearningStreaks(int userId)
    {
      throw new NotImplementedException();
    }

    public IReadOnlyCollection<LearningStreak> GetStreaks()
    {
      throw new NotImplementedException();
    }

    public int GetTotalScore(int userId, ILearningStreakCalculationStrategy calculator)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<DateTime> GetUniqueActivityDates(int userId)
    {
      throw new NotImplementedException();
    }

    public void Initialize(User user)
    {
      throw new NotImplementedException();
    }
  }
}