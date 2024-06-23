
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerDomain.Services
{
  public class LearningModuleService : ILearningModuleService
  {
    private readonly ILearningModuleRepository learningModuleRepository;
    private readonly IProgressService progressService;
    private readonly ILearningActivityService learningActivityService;

    public LearningModuleService(
        ILearningModuleRepository learningModuleRepository,
        IProgressService progressService,
        ILearningActivityService learningActivityService
        )
    {
      this.learningModuleRepository = learningModuleRepository ?? throw new System.ArgumentNullException(nameof(learningModuleRepository));
      this.progressService = progressService ?? throw new System.ArgumentNullException(nameof(progressService));
      this.learningActivityService = learningActivityService ?? throw new System.ArgumentNullException(nameof(learningActivityService));
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
    public IReadOnlyCollection<LearningModule> GetByUserId(int userId)
    {
      // Retrieve progress records for the user
      IEnumerable<Progress> userProgress = progressService.GetProgressByUserId(userId);
      if (userProgress == null || !userProgress.Any())
      {
        return new List<LearningModule>().AsReadOnly();
      }

      // Extract unique learning activity IDs from user progress
      List<int> uniqueLearningActivityIds = userProgress
        .Select(p => p.LearningActivityId)
        .Distinct()
        .ToList();

      // Retrieve learning activities by these IDs
      IEnumerable<LearningActivity> learningActivities = learningActivityService.GetActivitiesByIds(uniqueLearningActivityIds);
      if (learningActivities == null || !learningActivities.Any())
      {
        return new List<LearningModule>().AsReadOnly();
      }

      // Extract unique learning module IDs from learning activities
      List<int> associatedUniqueLearningModuleIds = learningActivities
        .Select(a => a.LearningModuleId)
        .Distinct()
        .ToList();

      // Retrieve learning modules by these IDs
      List<LearningModule> associatedLearningModules = learningModuleRepository.GetLearningModulesByIds(associatedUniqueLearningModuleIds);
      if (associatedLearningModules == null || !associatedLearningModules.Any())
      {
        return new List<LearningModule>().AsReadOnly();
      }

      return associatedLearningModules.ToList().AsReadOnly();
    }

    public LearningModule? GetLearningModuleByName(string name)
    {
      LearningModule? module = learningModuleRepository.GetLearningModuleByName(name);
      return module;
    }
  }
}
