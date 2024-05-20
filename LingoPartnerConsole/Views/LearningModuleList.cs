﻿using LingoPartnerDomain.classes;

namespace LingoPartnerConsole.Views
{
  public class LearningModuleList
  {
    private Administration SchoolAdministration;
    public LearningModuleList(Administration schoolAdministration)
    {
      SchoolAdministration = schoolAdministration;
    }
    public void Show()
    {
      Console.WriteLine("List of all LearningModules:\n");
      int index = 1;
      foreach (LearningModule module in SchoolAdministration.LearningModules)
      {
        Console.WriteLine($"{index++}. {module.Name} ({module.Description})");
      }
    }
  }
}