﻿using LingoPartnerDomain.classes;

namespace LingoPartnerConsole.Views
{
  public class LearningActivityList
  {
    private Administration SchoolAdministration;
    public LearningActivityList(Administration schoolAdministration)
    {
      SchoolAdministration = schoolAdministration;
    }
    public void Show()
    {
      Console.WriteLine("List of all LearningActivities:\n");
      int index = 1;
      foreach (LearningActivity activity in SchoolAdministration.LearningActivities)
      {
        Console.WriteLine($"{index++}. {activity.Name} ({activity.Description})");
      }
    }
  }
}