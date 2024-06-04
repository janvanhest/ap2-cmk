namespace LingoPartnerDomain.Classes
{
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
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public LearningModule(string name, string description)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
      Initialize(name, description);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public LearningModule(int id, string name, string description)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
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

    public IReadOnlyCollection<LearningActivity> ShowLearningActivities()
    {
      return new List<LearningActivity>(learningActivities);
    }

    public void UpdateModule(string newName, string newDescription)
    {
      Name = newName ?? throw new ArgumentNullException(nameof(newName));
      Description = newDescription ?? throw new ArgumentNullException(nameof(newDescription));
    }
  }
}