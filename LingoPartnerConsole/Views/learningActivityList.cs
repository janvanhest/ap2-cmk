using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerConsole.Views
{
  public class LearningActivityList
  {
    private ILearningActivityService learningActivityService;
    public LearningActivityList(ILearningActivityService learningActivityService)
    {
      this.learningActivityService = learningActivityService;
    }
    public void Show()
    {
      IReadOnlyList<LearningActivity> learningActivities = learningActivityService.GetAllActivities().ToList<LearningActivity>().AsReadOnly();
      int index = 1;
      foreach (LearningActivity activity in learningActivities)
      {
        Console.WriteLine($"{index++}. {activity.Name} ({activity.Description})");
      }
    }
  }
}