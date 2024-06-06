using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;
using Org.BouncyCastle.Asn1.Misc;

namespace LingoPartnerInfrastructure.Services
{
  public class LearningStreakService : ILearningStreakService
  {
    private readonly IProgressRepository progressRepository;
    private readonly IAuthenticationService authenticationService;
    private User user;

    public LearningStreakService(
      IProgressRepository progressRepository,
      IAuthenticationService authenticationService
    )
    {
      this.progressRepository = progressRepository;
      this.authenticationService = authenticationService;
      this.user = authenticationService.CurrentUser ?? throw new ArgumentNullException(nameof(authenticationService));
    }
    private List<Progress> GetProgressItems()
    {
      int userId = user.Id ?? throw new ArgumentNullException(nameof(user));
      return progressRepository.GetProgressByUserId(userId).ToList();
    }
    public List<LearningStreak> GetLearningStreaks()
    {
      List<LearningStreak> streaks = new List<LearningStreak>();
      var progressItems = GetProgressItems();
      if (!progressItems.Any()) return streaks;

      LearningStreak? currentStreak = null;

      for (int i = 0; i < progressItems.Count; i++)
      {
        var progress = progressItems[i];

        if (currentStreak == null)
        {
          currentStreak = new LearningStreak();
          currentStreak.AddActivityDate(progress.Date);
          streaks.Add(currentStreak);
        }
        else
        {
          var previousProgress = progressItems[i - 1];
          bool isNextDay = (progress.Date - previousProgress.Date).Days == 1;
          bool isWeekendSkip = previousProgress.Date.DayOfWeek == DayOfWeek.Friday && progress.Date.DayOfWeek == DayOfWeek.Sunday;

          if (isNextDay || isWeekendSkip)
          {
            currentStreak.AddActivityDate(progress.Date);
          }
          else
          {
            currentStreak.AddActivityDate(progress.Date);
            streaks.Add(currentStreak);
          }
        }
      }

      return streaks;
    }

    public int CalculateTotalScore()
    {
      return GetLearningStreaks().Sum(streak => streak.Score);
    }
    public LearningStreak? GetCurrentStreak() => GetLearningStreaks().LastOrDefault();
  }
}