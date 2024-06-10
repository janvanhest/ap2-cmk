
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerInfrastructure.Services
{
  public class LearningModuleService : ILearningModuleService
  {
    private readonly ILearningModuleRepository learningModuleRepository;

    public LearningModuleService(ILearningModuleRepository learningModuleRepository)
    {
      this.learningModuleRepository = learningModuleRepository ?? throw new System.ArgumentNullException(nameof(learningModuleRepository));
    }

    public IEnumerable<LearningModule> GetAllLearningModules()
    {
      try
      {
        return learningModuleRepository.GetAllLearningModules();
      }
      // FIXME: implement a nicer way to handle the ex
      catch (Exception ex)
      {
        // Handle exception, log it or rethrow it as a custom exception
        throw new ApplicationException("An error occurred while retrieving learning modules.", ex);
      }
    }
    // FIXME: Try to return with a result object, so we can handle the error in a better way
    public bool DeleteLearningModule(int id)
    {
      LearningModule? module = learningModuleRepository.GetLearningModuleById(id);
      if (module == null)
      {
        return false; // or throw a custom exception if preferred
      }
      try
      {
        return learningModuleRepository.DeleteLearningModule(id);
      }
      catch (Exception ex)
      {
        // Handle exception, log it or rethrow it as a custom exception
        throw new ApplicationException("An error occurred while deleting the learning module.", ex);
      }
    }

    public LearningModule? AddLearningModule(LearningModule newLearningModule)
    {
      return learningModuleRepository.AddLearningModule(newLearningModule);
    }

    public LearningModule? UpdateLearningModule(LearningModule learningModule)
    {
      return learningModuleRepository.UpdateLearningModule(learningModule);
    }

    public LearningModule? GetLearningModuleById(int id)
    {
      return learningModuleRepository.GetLearningModuleById(id);
    }

    // FIXME: Probably not need, as we are using the AddLearningModule method above, so delete it? 
    // public LearningModule? AddLearningModule(string name, string description)
    // {
    //   LearningModule newLearningModule = new LearningModule(name, description);
    //   return learningModuleRepository.AddLearningModule(newLearningModule);
    // }

  }
}
