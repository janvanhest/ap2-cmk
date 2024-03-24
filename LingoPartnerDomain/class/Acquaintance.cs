namespace LingoPartnerDomain.classes;
using LingoPartnerDomain.enums;

using System;
using System.Collections.Generic;

public class Acquaintance
{
  public Guid Id { get; private set; }
  public Student CurrentStudent { get; private set; } // The student who owns this list of acquaintances
  public List<Student> Friends { get; private set; }
  public List<FriendRequest> FriendRequests { get; private set; }

  // Constructor
  public Acquaintance(Student currentStudent)
  {
    Id = Guid.NewGuid();
    CurrentStudent = currentStudent ?? throw new ArgumentNullException(nameof(currentStudent));
    Friends = new List<Student>();
    FriendRequests = new List<FriendRequest>();
  }

  // Send a friend request to another student
  public void SendFriendRequest(Student friend)
  {
    var request = new FriendRequest(CurrentStudent, friend);
    FriendRequests.Add(request);
    // Additionally, you might want to add logic to notify the 'friend' of the request
  }

  // Respond to a friend request
  public void RespondToFriendRequest(FriendRequest request, FriendRequestStatus status)
  {
    request.Status = status;
    if (status == FriendRequestStatus.ACCEPTED)
    {
      Friends.Add(request.Sender); // or request.Receiver, depending on the logic
    }
    // You can add additional logic for other statuses
  }

  // Add a friend directly
  public void AddFriend(Student friend)
  {
    Friends.Add(friend);
  }

  // Remove a friend
  public void RemoveFriend(Student friend)
  {
    Friends.Remove(friend);
  }

  // List current friends
  public List<Student> GetFriends()
  {
    return Friends;
  }

  // You can add additional methods as needed
}


// Assuming the Student class is already defined
