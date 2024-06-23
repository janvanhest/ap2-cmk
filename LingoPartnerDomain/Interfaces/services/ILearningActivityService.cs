using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces.Services
{
  public interface ILearningActivityService
  {
    LearningActivity? CreateActivity(LearningActivity activity);
    LearningActivity? UpdateActivity(LearningActivity activity);
    void DeleteActivity(int activityId);
    LearningActivity? GetActivityById(int activityId);
    IEnumerable<LearningActivity> GetAllActivities();
    IEnumerable<LearningActivity> GetActivitiesByIds(IEnumerable<int> activityIds);
    IEnumerable<LearningActivity> GetLearningActivitiesByModuleId(int moduleId);
    LearningActivity? GetLearningActivityByName(string name);
  }
}
