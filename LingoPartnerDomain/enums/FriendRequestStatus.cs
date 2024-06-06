namespace LingoPartnerDomain.enums;
using System.ComponentModel;
public enum FriendRequestStatus
{
  [Description("Accepted")]
  ACCEPTED,
  [Description("Declined")]
  DECLINED,
  [Description("Pending")]
  PENDING,
  [Description("Canceled")]
  CANCELED,
  [Description("Blocked")]
  BLOCKED,
  [Description("Unblocked")]
  UNBLOCKED
}
