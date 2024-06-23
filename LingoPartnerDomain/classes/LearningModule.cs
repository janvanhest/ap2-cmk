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
    public LearningModule(string name, string description) : this(null, name, description) { }
    public LearningModule(int? id, string name, string description)
    {
      Id = id;
      Name = name ?? throw new ArgumentNullException(nameof(name));
      Description = description ?? throw new ArgumentNullException(nameof(description));
    }
  }
}