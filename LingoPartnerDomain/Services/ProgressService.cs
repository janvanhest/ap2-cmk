using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerShared.Helpers;

namespace LingoPartnerDomain.Services
{
  public class ProgressService : IProgressService
  {
    private readonly IProgressRepository _progressRepository;
    private readonly ILearningActivityService _learningActivityService;

    public ProgressService(
      IProgressRepository progressRepository,
      ILearningActivityService learningActivityService
      )
    {
      _progressRepository = progressRepository;
      _learningActivityService = learningActivityService;
    }

    public Progress? AddProgress(Progress progress)
    {
      return _progressRepository.AddProgress(progress);
    }

    public Progress? UpdateProgress(Progress progress)
    {
      return _progressRepository.UpdateProgress(progress);
    }

    public IEnumerable<Progress> GetAllProgress()
    {
      return _progressRepository.GetAllProgress();
    }

    public IEnumerable<Progress> GetProgressByUserId(int userId)
    {
      return _progressRepository.GetProgressByUserId(userId);
    }

    public IEnumerable<DateTime> GetUniqueDatesByUserId(int userId)
    {
      return _progressRepository.GetUniqueDatesByUserId(userId);
    }

    public double GetModuleCompletionPercentage(int moduleId, User? user)
    {
      if (user == null) throw new ArgumentNullException(nameof(user));
      if (user.Id == null) throw new ArgumentNullException(nameof(user.Id));

      int userId = user.Id.Value;
      var activitiesByLearningModuleId = _learningActivityService.GetLearningActivitiesByModuleId(moduleId).ToList();
      if (activitiesByLearningModuleId.Count == 0) return 0;

      // retrieve all completed activities for the user. Only retrieve single values of completed activities. Make sure they are unique.
      var completedActivities = _progressRepository
          .GetProgressByUserId(userId)
          .Where(p => p.Status == ProgressStatus.COMPLETED && activitiesByLearningModuleId.Any(la => la.Id == p.LearningActivityId))
          .Count();

      return (double)completedActivities * 100 / activitiesByLearningModuleId.Count;
    }
  }
}
