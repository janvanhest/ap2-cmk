using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;

namespace LingoPartnerDomain.Interfaces.Repositories
{
  public interface IFriendRequestRepository
  {
    FriendRequest? AddFriendRequest(FriendRequest friendRequest);
    void UpdateFriendRequestStatus(int friendRequestId, FriendRequestStatus status);
    FriendRequest? GetFriendRequestById(int friendRequestId);
    List<FriendRequest>? GetFriendRequestsByUserId(int userId);
    // delete friend request by id
    void DeleteFriendRequestById(int friendRequestId);
  }
}