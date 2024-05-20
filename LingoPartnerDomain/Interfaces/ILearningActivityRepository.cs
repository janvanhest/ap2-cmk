using LingoPartnerDomain.classes;

namespace LingoPartnerDomain
{
  public interface ILearningActivityRepository
  {
    void AddLearningActivity(LearningActivity activity);
    void UpdateLearningActivity(LearningActivity activity);
    void RemoveLearningActivity(int activityId);
    LearningActivity GetLearningActivityById(int activityId);
    IEnumerable<LearningActivity> GetAllLearningActivities();
  }
}