using LingoPartnerDomain.classes;

namespace LingoPartnerDomain
{
  public interface ILearningActivityRepository
  {
    LearningActivity? AddLearningActivity(LearningActivity activity);
    LearningActivity? UpdateLearningActivity(LearningActivity activity);
    void RemoveLearningActivity(int activityId);
    LearningActivity? GetLearningActivityById(int activityId);
    IEnumerable<LearningActivity> GetAllLearningActivities();
  }
}