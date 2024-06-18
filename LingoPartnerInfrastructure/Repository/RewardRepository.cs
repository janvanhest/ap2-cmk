using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerInfrastructure.Helpers;
using MySql.Data.MySqlClient;

namespace LingoPartnerInfrastructure
{
  public class RewardRepository
  // : IRewardRepository
  {
    private readonly string connectionString;
    public RewardRepository(string connectionString)
    {
      this.connectionString = connectionString != null ?
        connectionString :
        InfrastructureHelper.CreateConnectionString();
    }

    // public Reward? AddReward(Reward reward)
    // {
    //   using (MySqlConnection connection = new(connectionString))
    //   {
    //     connection.Open();
    //     using (MySqlTransaction transaction = connection.BeginTransaction())
    //     {
    //       try
    //       {
    //         string query = @"
    //           INSERT INTO Reward (UserId, RewardType, RewardAmount)
    //           VALUES (@UserId, @RewardType, @RewardAmount);
    //           SELECT LAST_INSERT_ID();";

    //         using (MySqlCommand command = new(query, connection, transaction))
    //         {
    //           command.Parameters.AddWithValue("@UserId", reward.userId);
    //           command.Parameters.AddWithValue("@RewardType", reward.Type.ToString());
    //           command.Parameters.AddWithValue("@RewardAmount", reward.RewardAmount);

    //           object result = command.ExecuteScalar();
    //           if (result != null)
    //           {
    //             transaction.Commit();
    //             return new Reward(
    //               Convert.ToInt32(result),
    //               reward.UserId,
    //               reward.RewardType,
    //               reward.RewardAmount
    //             );
    //           }
    //           else
    //           {
    //             transaction.Rollback();
    //             return null;
    //           }
    //         }
    //       }
    //       catch (MySqlException ex)
    //       {
    //         LoggingHelper.LogError(ex, $"Error adding reward for user {reward.UserId}\n {ex.Message}");
    //       }
    //     }
    //   }
    // }

    // public Reward? GetRewardById(int rewardId)
    // {
    // }

    // public List<Reward>? GetRewardsByUserId(int userId)
    // {
    // }
  }
}
