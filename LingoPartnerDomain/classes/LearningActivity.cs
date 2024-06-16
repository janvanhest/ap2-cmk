using LingoPartnerDomain.enums;
namespace LingoPartnerDomain.Classes
{
  public class LearningActivity
  {
    public int? Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public LearningActivityType Type { get; private set; }
    public int LearningModuleId { get; private set; }

    // Constructor to initialize a new LearningActivity
    public LearningActivity(
        string name,
        string description,
        LearningActivityType type,
        int learningModuleId) : this(
            null,
            name,
            description,
            type,
            learningModuleId)
    { }
    public LearningActivity(int? id, string name, string description, LearningActivityType type, int learningModuleId)
    {
      Id = id;
      Name = name ?? throw new ArgumentNullException(nameof(name));
      Description = description ?? throw new ArgumentNullException(nameof(description));
      Type = type;
      LearningModuleId = learningModuleId == 0 ? throw new ArgumentNullException(nameof(learningModuleId)) : learningModuleId;
    }

    // Method to update the details of the learning activity
    public void UpdateActivity(LearningActivity newActivity)
    {
      Name = newActivity.Name;
      Description = newActivity.Description;
      Type = newActivity.Type;
    }
  }
}