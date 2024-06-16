using System.Collections.ObjectModel;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerConsole.Views
{
  public class LearningModuleList
  {
    private ILearningModuleService learningModuleService;
    public LearningModuleList(ILearningModuleService learningModuleService)
    {
      this.learningModuleService = learningModuleService;
    }
    public void Show()
    {
      ReadOnlyCollection<LearningModule> learningModules = learningModuleService.GetAllLearningModules().ToList<LearningModule>().AsReadOnly();
      int index = 1;
      foreach (LearningModule module in learningModules)
      {
        Console.WriteLine($"{index++}. {module.Name} ({module.Description})");
      }
    }
  }
}