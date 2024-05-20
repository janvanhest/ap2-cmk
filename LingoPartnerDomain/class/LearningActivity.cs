namespace LingoPartnerDomain.classes;
using LingoPartnerDomain.enums;

public class LearningActivity
{
  public int? Id { get; private set; }
  public string Name { get; private set; }
  public string Description { get; private set; }
  public LearningActivityType Type { get; private set; }

  // Constructor to initialize a new LearningActivity
  public LearningActivity(string name, string description, LearningActivityType type)
  {
    Name = name ?? throw new ArgumentNullException(nameof(name));
    Description = description ?? throw new ArgumentNullException(nameof(description));
    Type = type;
  }

  public LearningActivity(int id, string name, string description, LearningActivityType type)
  {
    Id = id;
    Name = name ?? throw new ArgumentNullException(nameof(name));
    Description = description ?? throw new ArgumentNullException(nameof(description));
    Type = type;
  }

  // Method to update the details of the learning activity
  public void UpdateActivity(string newName, string newDescription, LearningActivityType newType)
  {
    Name = newName ?? throw new ArgumentNullException(nameof(newName));
    Description = newDescription ?? throw new ArgumentNullException(nameof(newDescription));
    Type = newType;
  }
}
