using System;
namespace LingoPartnerDomain.classes
{
  public class Reward
  {
    public int Id { get; private set; }
    public string Name { get; private set; }
    public RewardType Type { get; private set; }
    public string Description { get; private set; }
    public string Criteria { get; private set; } // Criteria to achieve the reward

    // Constructor to initialize a new Reward
    public Reward(string name, RewardType type, string description, string criteria)
    {
      Name = name ?? throw new ArgumentNullException(nameof(name));
      Type = type;
      Description = description ?? throw new ArgumentNullException(nameof(description));
      Criteria = criteria ?? throw new ArgumentNullException(nameof(criteria));
    }

    // Method to update the details of the reward
    public void UpdateReward(string newName, RewardType newType, string newDescription, string newCriteria)
    {
      Name = newName ?? throw new ArgumentNullException(nameof(newName));
      Type = newType;
      Description = newDescription ?? throw new ArgumentNullException(nameof(newDescription));
      Criteria = newCriteria ?? throw new ArgumentNullException(nameof(newCriteria));
    }

    // You can add more methods if needed, such as methods to determine if a student has met the criteria for the reward
  }

  // Enum for different types of rewards
  public enum RewardType
  {
    Diploma,
    Badge
    // You can add more types as needed
  }
}