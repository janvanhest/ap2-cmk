using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces.Repositories
{
  public interface ILearningModuleRepository
  {
    LearningModule? AddLearningModule(LearningModule module);
    IEnumerable<LearningModule> GetAllLearningModules();
    LearningModule? GetLearningModuleById(int id);
    List<LearningModule> GetLearningModulesByIds(IEnumerable<int> ids);
    LearningModule? UpdateLearningModule(LearningModule module);
    Boolean DeleteLearningModule(int id);
    LearningModule? GetLearningModuleByName(string name);
  }
}