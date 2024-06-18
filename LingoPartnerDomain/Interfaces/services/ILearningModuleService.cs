
using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces.Services
{
  public interface ILearningModuleService
  {
    IEnumerable<LearningModule> GetAllLearningModules();
    LearningModule? GetLearningModuleById(int id);
    LearningModule? AddLearningModule(LearningModule learningModule);
    LearningModule? UpdateLearningModule(LearningModule learningModule);
    bool DeleteLearningModule(int id);
    IReadOnlyCollection<LearningModule> GetByUserId(int userId);
  }
}
