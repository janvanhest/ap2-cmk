using System.Dynamic;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerDomain.Interfaces.Strategies;
using LingoPartnerDomain.Strategies;
using LingoPartnerDomain.Strategies.Scoring;

namespace LingoPartnerInfrastructure.Services
{
  public class LearningStreakService : ILearningStreakService
  {
    private readonly IProgressRepository progressRepository;
    private readonly IAuthenticationService authenticationService;
    private ILearningStreakStrategy learningStreakStrategy;
    private ILearningStreakScoringStrategy scoringStrategy;
    private User user;

    public LearningStreakService(
        IProgressRepository progressRepository,
        IAuthenticationService authenticationService,
        ILearningStreakStrategy learningStreakStrategy,
        ILearningStreakScoringStrategy scoringStrategy
    )
    {
      this.progressRepository = progressRepository ?? throw new ArgumentNullException(nameof(progressRepository));
      this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
      this.learningStreakStrategy = learningStreakStrategy ?? new ConsecutiveDaysStrategy();
      this.scoringStrategy = scoringStrategy ?? new SimpleScoringStrategy();
      this.user = this.authenticationService.CurrentUser ?? throw new ArgumentNullException(nameof(user));

    }

    public void SetLearningStreakStrategy(ILearningStreakStrategy learningStreakStrategy)
    {
      this.learningStreakStrategy = learningStreakStrategy;
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
        ConvertProgressToUniqueDates(GetProgressItems()),
        scoringStrategy
        );

    public int CalculateTotalScore(ILearningStreakScoringStrategy? scoringStrategy)
    {
      ILearningStreakScoringStrategy currentscoringStrategy = scoringStrategy ?? this.scoringStrategy; // 
      return GetLearningStreaks() != null ? GetLearningStreaks().Sum(streak => currentscoringStrategy.CalculateScore(streak)) : 0;
    }
    public LearningStreak? GetCurrentStreak() => GetLearningStreaks().LastOrDefault();
  }
}