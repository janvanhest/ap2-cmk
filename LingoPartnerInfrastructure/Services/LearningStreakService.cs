using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerDomain.Interfaces.Strategies;

namespace LingoPartnerInfrastructure.Services
{
  public class LearningStreakService : ILearningStreakService
  {
    private readonly IProgressRepository progressRepository;
    private readonly IAuthenticationService authenticationService;
    private readonly ILearningStreakStrategy learningStreakStrategy;
    private User user;

    public LearningStreakService(
        IProgressRepository progressRepository,
        IAuthenticationService authenticationService,
        ILearningStreakStrategy learningStreakStrategy
    )
    {
      this.progressRepository = progressRepository ?? throw new ArgumentNullException(nameof(progressRepository));
      this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
      this.learningStreakStrategy = learningStreakStrategy ?? throw new ArgumentNullException(nameof(learningStreakStrategy));
      this.user = this.authenticationService.CurrentUser ?? throw new ArgumentNullException(nameof(user));

    }

    private List<Progress> GetProgressItems()
    {
      int userId = user.Id ?? throw new ArgumentNullException(nameof(user));
      return progressRepository.GetProgressByUserId(userId).ToList();
    }

    private List<DateTime> ConvertProgressToUniqueDates(List<Progress> progressItems)
    {
      return progressItems
          .GroupBy(p => p.Date.Date)
          .Select(g => g.Key)
          .OrderBy(date => date)
          .ToList();
    }

    public List<LearningStreak> GetLearningStreaks() =>
      learningStreakStrategy.GetLearningStreaks(
        ConvertProgressToUniqueDates(GetProgressItems()));

    public int CalculateTotalScore()
    {
      return GetLearningStreaks().Sum(streak => streak.Score);
    }
    public LearningStreak? GetCurrentStreak() => GetLearningStreaks().LastOrDefault();
  }
}