namespace LingoPartnerDomain.classes;

using System;
using System.Collections.Generic;
using LingoPartnerDomain.enums;

public class LearningModule
{
  public Guid Id { get; private set; }
  public string Name { get; private set; }
  public string Description { get; private set; }
  private List<LearningActivity> learningActivities;

  public LearningModule(string name, string description)
  {
    Id = Guid.NewGuid();
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

public class LearningActivity
{
  public Guid Id { get; private set; }
  public string Name { get; private set; }
  public string Description { get; private set; }
  public LearningActivityType Type { get; private set; }

  public LearningActivity(string name, string description, LearningActivityType type)
  {
    Id = Guid.NewGuid();
    Name = name;
    Description = description;
    Type = type;
  }
  public void UpdateActivity(string newName, string newDescription, LearningActivityType newType)
  {
    Name = newName ?? throw new ArgumentNullException(nameof(newName));
    Description = newDescription ?? throw new ArgumentNullException(nameof(newDescription));
    Type = newType;
  }
}