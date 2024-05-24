using LingoPartnerConsole.helpers;
using LingoPartnerDomain.classes;
using LingoPartnerDomain.enums;

namespace LingoPartnerConsole.Views
{
  public class LearningActivityAdd
  {
    private Administration SchoolAdministration;
    public LearningActivityAdd(Administration schoolAdministration)
    {
      SchoolAdministration = schoolAdministration;
    }
    public void Show(int learningModuleId)
    {
      ConsoleHelper.DisplayTypingAnimation("Add a new LearningActivity:\n");
      string name = ConsoleHelper.GetStringInput("Enter name:");
      string description = ConsoleHelper.GetStringInput("Enter description:");
      LearningActivityType type = ConsoleHelper.GetLearningActivityType();
      LearningActivity newLearningActivity = new LearningActivity(
          name: name,
          description: description,
          type: type,
          learningModuleId: learningModuleId
      );
      SchoolAdministration.AddLearningActivity(learningModuleId, newLearningActivity);
    }
  }
}
