using LingoPartnerDomain.enums;

namespace LingoPartnerDomain.Classes
{
  public class FriendRequest
  {
    public int Id { get; private set; }
    public User Sender { get; private set; }
    public User Recipient { get; private set; }
    public FriendRequestStatus Status { get; private set; }

    public FriendRequest(int id, User sender, User recipient)
    {
      Id = id;
      Sender = sender;
      Recipient = recipient;
      Status = FriendRequestStatus.PENDING;  // Default status
    }

    public void UpdateStatus(FriendRequestStatus newStatus)
    {
      Status = newStatus;
    }
  }
}