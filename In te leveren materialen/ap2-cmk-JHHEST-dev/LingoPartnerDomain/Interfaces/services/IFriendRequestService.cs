using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;

namespace LingoPartnerDomain.Interfaces.Services
{
  public interface IFriendRequestService
  {
    FriendRequest? AddFriendRequest(FriendRequest friendRequest);
    void UpdateFriendRequestStatus(int friendRequestId, FriendRequestStatus status);
    FriendRequest? GetFriendRequestById(int friendRequestId);
    List<FriendRequest>? GetFriendRequestsByUserId(int userId);
    void DeleteFriendRequestById(int friendRequestId);
  }
}
