using LingoPartnerDomain.enums;

namespace LingoPartnerDomain.Classes
{
  public class FriendRequest
  {
    private readonly int? id;
    public int SenderId { get; private set; }
    public int RecipientId { get; private set; }
    public FriendRequestStatus Status { get; private set; }

    public FriendRequest(int senderId, int recipientId)
        : this(null, senderId, recipientId) { }
    public FriendRequest(int? id, int senderId, int recipientId)
    {
      ValidateIds(senderId, recipientId);
      this.id = id;
      this.SenderId = senderId;
      this.RecipientId = recipientId;
      this.Status = FriendRequestStatus.PENDING;
    }

    public void UpdateStatus(FriendRequestStatus newStatus)
    {
      this.Status = newStatus;
    }

    private void ValidateIds(int senderId, int recipientId)
    {
      if (senderId <= 0 || recipientId <= 0 || senderId == recipientId)
      {
        throw new ArgumentException("Invalid sender or recipient ID.");
      }
    }
  }
}
