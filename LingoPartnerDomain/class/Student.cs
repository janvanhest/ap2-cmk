namespace LingoPartnerDomain.classes;

using System;
using System.Collections.Generic;
using System.Net.Mail;

// Assuming User class is already defined as per your diagram
public class Student : User
{
  public List<Progress> ProgressRecords { get; private set; }
  public List<Reward> Rewards { get; private set; }
  public List<Acquaintance> Friends { get; private set; }

  // Constructor
  public Student(Guid id, string firstName, string middleName, string lastName,
                 DateTime dateOfBirth, MailAddress email, string password, string userName)
      : base(id, firstName, middleName, lastName, dateOfBirth, email, password, userName)
  {
    ProgressRecords = new List<Progress>();
    Rewards = new List<Reward>();
    Friends = new List<Acquaintance>();
  }

  // Methods for progress management
  public void AddProgress(Progress progress)
  {
    ProgressRecords.Add(progress);
  }

  public void UpdateProgress(Progress updatedProgress)
  {
    // Implementation to update a specific progress record
    // This can involve finding the progress record by its ID and updating it
  }

  public List<Progress> ShowProgress()
  {
    return ProgressRecords;
  }

  // Methods for reward management
  public void AddReward(Reward reward)
  {
    Rewards.Add(reward);
  }

  public List<Reward> ShowRewards()
  {
    return Rewards;
  }

  // Methods for managing friends/acquaintances
  public void AddFriend(Acquaintance friend)
  {
    Friends.Add(friend);
  }

  public void RemoveFriend(Acquaintance friend)
  {
    Friends.Remove(friend);
  }

  public List<Acquaintance> ShowFriends()
  {
    return Friends;
  }

  // Additional student-specific methods can be added as needed
}

// Assuming other classes (User, Progress, Reward, Acquaintance) are already defined

