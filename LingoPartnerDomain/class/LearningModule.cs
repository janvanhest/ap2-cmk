namespace LingoPartnerDomain.classes;

using System;
using System.Collections.Generic;
using LingoPartnerDomain.enums;

public class LearningModule
{
  public int Id { get; private set; }
  public string Name { get; private set; }
  public string Description { get; private set; }
  private List<LearningActivity> learningActivities;

  public LearningModule(string name, string description)
  {
    Name = name;
    Description = description;
    learningActivities = new List<LearningActivity>();
  }

  public void AddLearningActivity(LearningActivity activity)
  {
    if (activity == null)
    {
      throw new ArgumentNullException(nameof(activity));
    }

    learningActivities.Add(activity);
  }

  public bool RemoveLearningActivity(LearningActivity activity)
  {
    return learningActivities.Remove(activity);
  }

  public List<LearningActivity> ShowLearningActivities()
  {
    return new List<LearningActivity>(learningActivities);
  }

  public void UpdateModule(string newName, string newDescription)
  {
    Name = newName ?? throw new ArgumentNullException(nameof(newName));
    Description = newDescription ?? throw new ArgumentNullException(nameof(newDescription));
  }
}