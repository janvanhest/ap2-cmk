using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces;
using LingoPartnerDomain.Services;

namespace LingoPartnerInfrastructure.Services
{
  public class LearningStreakService : ILearningStreakService
  {
    private readonly IProgressRepository _progressRepository;

    public LearningStreakService(IProgressRepository progressRepository)
    {
      _progressRepository = progressRepository;
    }

    public int GetCurrentLearningStreak(User user)
    {
      // Placeholder for getting current learning streak
      // Logic to calculate the current learning streak from progress data
      return 0; // Replace with actual calculation
    }

    public int GetTotalScore(User user)
    {
      // Placeholder for getting total score
      // Logic to calculate the total score from progress data
      return 0; // Replace with actual calculation
    }
  }
}