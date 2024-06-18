using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerDomain.Services
{
  public class FriendRequestService : IFriendRequestService
  {
    private readonly IFriendRequestRepository _friendRequestRepository;

    public FriendRequestService(IFriendRequestRepository friendRequestRepository)
    {
      _friendRequestRepository = friendRequestRepository ?? throw new ArgumentNullException(nameof(friendRequestRepository));
    }

    public FriendRequest? AddFriendRequest(FriendRequest friendRequest)
    {
      return _friendRequestRepository.AddFriendRequest(friendRequest);
    }

    public void UpdateFriendRequestStatus(int friendRequestId, FriendRequestStatus status)
    {
      _friendRequestRepository.UpdateFriendRequestStatus(friendRequestId, status);
    }

    public FriendRequest? GetFriendRequestById(int friendRequestId)
    {
      return _friendRequestRepository.GetFriendRequestById(friendRequestId);
    }

    public List<FriendRequest>? GetFriendRequestsByUserId(int userId)
    {
      return _friendRequestRepository.GetFriendRequestsByUserId(userId);
    }

    public void DeleteFriendRequestById(int friendRequestId)
    {
      _friendRequestRepository.DeleteFriendRequestById(friendRequestId);
    }
  }
}
