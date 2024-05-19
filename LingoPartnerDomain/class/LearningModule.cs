namespace LingoPartnerDomain.classes;

using System;
using System.Collections.Generic;
using LingoPartnerDomain.enums;

public class LearningModule
{
  public int? Id { get; private set; }
  public string Name { get; private set; }
  public string Description { get; private set; }
  private List<LearningActivity> LearningActivities = new List<LearningActivity>();
  public IReadOnlyList<LearningActivity> learningActivities
  { get { return learningActivities; } }


  public void Initialize(string name, string description)
  {
    Name = name ?? throw new ArgumentNullException(nameof(name));
    Description = description ?? throw new ArgumentNullException(nameof(description));
  }
  public LearningModule(string name, string description)
  {
    Initialize(name, description);
  }

  public LearningModule(int id, string name, string description)
  {
    Id = id;
    Initialize(name, description);
  }

  public void AddLearningActivity(LearningActivity activity)
  {
    if (activity == null)
    {
      throw new ArgumentNullException(nameof(activity));
    }
    LearningActivities.Add(activity);
  }

  public bool RemoveLearningActivity(LearningActivity activity)
  {
    return LearningActivities.Remove(activity);
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