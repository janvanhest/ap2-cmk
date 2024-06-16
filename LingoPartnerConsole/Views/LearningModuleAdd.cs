using LingoPartnerConsole.Helpers;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerConsole
{
  public class LearningModuleAdd
  {
    private ILearningModuleService learningModuleService;

    public LearningModuleAdd(ILearningModuleService learningModuleService)
    {
      this.learningModuleService = learningModuleService ?? throw new ArgumentNullException(nameof(learningModuleService));
    }

    public void Show()
    {
      string name = ConsoleHelper.GetStringInput("Enter name:");
      string description = ConsoleHelper.GetStringInput("Enter description:");

      // Create the learning module object
      LearningModule newLearningModule = new(
          name: name,
          description: description
      );
      // Add the learning module to the administration
      learningModuleService.AddLearningModule(newLearningModule);
      Console.WriteLine($"Learning module {name} successfully added.");
    }
  }
}
