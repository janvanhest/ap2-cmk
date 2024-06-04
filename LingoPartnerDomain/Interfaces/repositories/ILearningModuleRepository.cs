using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces.Repositories
{
  public interface ILearningModuleRepository
  {
    LearningModule? AddLearningModule(LearningModule module);
    IEnumerable<LearningModule> GetAllLearningModules();
    // TODO: Implement GetLearningModuleById
    LearningModule? GetLearningModuleById(int id);
    // TODO: Implement UpdateLearningModule
    LearningModule? UpdateLearningModule(LearningModule module);
    // TODO: Implement DeleteLearningModule
    Boolean DeleteLearningModule(int id);
  }
}