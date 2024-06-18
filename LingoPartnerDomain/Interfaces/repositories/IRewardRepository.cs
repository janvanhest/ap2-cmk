using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces.Repositories
{
  public interface IRewardRepository
  {
    Reward? AddReward(Reward reward);
    Reward? GetRewardById(int rewardId);
    List<Reward>? GetRewardsByUserId(int userId);
  }
}