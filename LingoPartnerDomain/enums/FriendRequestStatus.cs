namespace LingoPartnerDomain;
using System.ComponentModel;
public enum FriendRequestStatusENUM
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
