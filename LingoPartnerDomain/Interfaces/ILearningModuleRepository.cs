using LingoPartnerDomain.classes;
using System.Collections.Generic;

namespace LingoPartnerDomain.Interfaces
{
  public interface ILearningModuleRepository
  {
    LearningModule? AddLearningModule(LearningModule module);
    IEnumerable<LearningModule> GetAllLearningModules();
    // TODO: Implement GetLearningModuleById
    // LearningModule? GetLearningModuleById(int id);
    // TODO: Implement UpdateLearningModule
    // void UpdateLearningModule(LearningModule module);
    // TODO: Implement DeleteLearningModule
    // void DeleteLearningModule(int id);
  }
}