using LingoPartnerConsole.helpers;
using LingoPartnerDomain.classes;

namespace LingoPartnerConsole
{
  public class LearningModuleAdd
  {
    private Administration SchoolAdministration;

    public LearningModuleAdd(Administration administration)
    {
      SchoolAdministration = administration;
    }

    public void Show()
    {
      string name = ConsoleHelper.GetStringInput("Enter name:");
      string description = ConsoleHelper.GetStringInput("Enter description:");

      // Create the learning module object
      LearningModule newLearningModule = new LearningModule(
          name: name,
          description: description
      );
      // Add the learning module to the administration
      SchoolAdministration.Add(newLearningModule);
      Console.WriteLine($"Learning module {name} successfully added.");
    }
  }
}
