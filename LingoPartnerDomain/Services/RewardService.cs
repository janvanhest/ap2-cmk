using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerDomain.Services
{
  public class RewardService : IRewardService
  {
    private readonly IRewardRepository _rewardRepository;

    public RewardService(IRewardRepository rewardRepository)
    {
      _rewardRepository = rewardRepository ?? throw new ArgumentNullException(nameof(rewardRepository));
    }

    public Reward? AddReward(Reward reward)
    {
      return _rewardRepository.AddReward(reward);
    }

    public Reward? GetRewardById(int rewardId)
    {
      return _rewardRepository.GetRewardById(rewardId);
    }

    public List<Reward>? GetRewardsByUserId(int userId)
    {
      return _rewardRepository.GetRewardsByUserId(userId);
    }
  }
}
