using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerDomain.Services
{
  public class LearningActivityService : ILearningActivityService
  {
    private readonly ILearningActivityRepository _learningActivityRepository;

    public LearningActivityService(ILearningActivityRepository learningActivityRepository)
    {
      _learningActivityRepository = learningActivityRepository;
    }

    public LearningActivity? CreateActivity(LearningActivity activity)
    {
      return _learningActivityRepository.Add(activity);
    }

    public LearningActivity? UpdateActivity(LearningActivity activity)
    {
      return _learningActivityRepository.Update(activity);
    }

    public void DeleteActivity(int activityId)
    {
      _learningActivityRepository.Remove(activityId);
    }

    public LearningActivity? GetActivityById(int activityId)
    {
      return _learningActivityRepository.GetById(activityId);
    }

    public IEnumerable<LearningActivity> GetAllActivities()
    {
      return _learningActivityRepository.GetAll();
    }

    public IEnumerable<LearningActivity> GetActivitiesByIds(IEnumerable<int> activityIds)
    {
      return _learningActivityRepository.GetByIds(activityIds);
    }

    public IEnumerable<LearningActivity> GetLearningActivitiesByModuleId(int moduleId)
    {
      return _learningActivityRepository.GetByLearningModuleId(moduleId);
    }

    public LearningActivity? GetLearningActivityByName(string name)
    {
      return _learningActivityRepository.GetByName(name);
    }
  }
}
