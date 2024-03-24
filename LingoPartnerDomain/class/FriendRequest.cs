using LingoPartnerDomain.classes;
using LingoPartnerDomain.enums;

namespace LingoPartnerDomain;

public class FriendRequest
{
  public Student Sender { get; set; }
  public Student Receiver { get; set; }
  public FriendRequestStatus Status { get; set; }

  public FriendRequest(Student sender, Student receiver)
  {
    Sender = sender;
    Receiver = receiver;
    Status = FriendRequestStatus.PENDING;
  }
}
