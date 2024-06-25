using LingoPartnerConsole.Helpers;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerConsole.Views
{
  public class LearningActivityAdd
  {
    private ILearningActivityService learningActivityService;
    public LearningActivityAdd(ILearningActivityService learningActivityService)
    {
      this.learningActivityService = learningActivityService;
    }
    public void Show(int learningModuleId)
    {
      ConsoleHelper.DisplayTypingAnimation("Add a new LearningActivity:\n");
      string name;
      while (true)
      {
        name = ConsoleHelper.GetStringInput("Enter name:");
        if (learningActivityService.GetLearningActivityByName(name) == null)
        {
          break;
        }
        Console.WriteLine("Learning activity already exists. Please enter a different name.");
      }
      string description = ConsoleHelper.GetStringInput("Enter description:");
      LearningActivityType type = ConsoleHelper.GetLearningActivityType();
      LearningActivity newLearningActivity = new LearningActivity(
          name: name,
          description: description,
          type: type,
          learningModuleId: learningModuleId
      );
      learningActivityService.CreateActivity(newLearningActivity);
    }
  }
}
