namespace LingoPartnerDomain.Classes
{
  public class Reward
  {
    public int? Id { get; private set; }
    public string Name { get; private set; }
    public RewardType Type { get; private set; }
    public string Description { get; private set; }
    public string Criteria { get; private set; } // Criteria to achieve the reward
    public int userId { get; private set; }

    // Constructor to initialize a new Reward
    public Reward(
        string name,
        RewardType type,
        string description,
        string criteria,
        int userId
        ) : this(null, name, type, description, criteria, userId) { }
    public Reward(
        int? id,
        string name,
        RewardType type,
        string description,
        string criteria,
        int userId
        )
    {
      Id = id;
      Name = name ?? throw new ArgumentNullException(nameof(name));
      Type = type;
      Description = description ?? throw new ArgumentNullException(nameof(description));
      Criteria = criteria ?? throw new ArgumentNullException(nameof(criteria));
      // userId can't be null
      this.userId = userId > 0 ? userId : throw new ArgumentException("Invalid user ID.", nameof(userId));
    }

    public void UpdateReward(string newName, RewardType newType, string newDescription, string newCriteria)
    {
      Name = newName ?? throw new ArgumentNullException(nameof(newName));
      Type = newType;
      Description = newDescription ?? throw new ArgumentNullException(nameof(newDescription));
      Criteria = newCriteria ?? throw new ArgumentNullException(nameof(newCriteria));
    }
  }

  public enum RewardType
  {
    Diploma,
    Badge
  }
}