using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

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
      this.progressRepository = progressRepository ?? throw new ArgumentNullException(nameof(progressRepository));
      this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
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
    public List<LearningStreak> GetLearningStreaks()
    {
      List<DateTime> uniqueDates = ConvertProgressToUniqueDates(GetProgressItems());
      List<LearningStreak> streaks = new List<LearningStreak>();

      if (!uniqueDates.Any()) return streaks;

      LearningStreak? currentStreak = null;

      for (int i = 0; i < uniqueDates.Count; i++)
      {
        var date = uniqueDates[i];

        if (currentStreak == null)
        {
          currentStreak = new LearningStreak();
          currentStreak.AddActivityDate(date);
          streaks.Add(currentStreak);
        }
        else
        {
          var previousDate = uniqueDates[i - 1];
          bool isNextDay = (date - previousDate).Days == 1;
          bool isWeekendSkip = previousDate.DayOfWeek == DayOfWeek.Friday && date.DayOfWeek == DayOfWeek.Sunday;

          if (isNextDay || isWeekendSkip)
          {
            currentStreak.AddActivityDate(date);
          }
          else
          {
            currentStreak = new LearningStreak();
            currentStreak.AddActivityDate(date);
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