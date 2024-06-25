using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces.Repositories
{
  public interface ILearningActivityRepository
  {
    LearningActivity? Add(LearningActivity activity);
    LearningActivity? Update(LearningActivity activity);
    void Remove(int activityId);
    LearningActivity? GetById(int activityId);
    IEnumerable<LearningActivity> GetByIds(IEnumerable<int> activityIds);
    IEnumerable<LearningActivity> GetAll();
    IEnumerable<LearningActivity> GetByLearningModuleId(int moduleId);
    LearningActivity? GetByName(string name);
  }
}