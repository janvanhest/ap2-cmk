using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces
{
  public interface ILearningActivityRepository
  {
    LearningActivity? Add(LearningActivity activity);
    LearningActivity? Update(LearningActivity activity);
    void Remove(int activityId);
    LearningActivity? GetById(int activityId);
    IEnumerable<LearningActivity> GetAll();
  }
}