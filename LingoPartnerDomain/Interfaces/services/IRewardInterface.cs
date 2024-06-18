using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces.Services
{
  public interface IRewardService
  {
    Reward? AddReward(Reward reward);
    Reward? GetRewardById(int rewardId);
    List<Reward>? GetRewardsByUserId(int userId);
  }
}
