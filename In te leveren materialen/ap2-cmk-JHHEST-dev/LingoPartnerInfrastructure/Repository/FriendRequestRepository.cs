using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerInfrastructure.Helpers;
using LingoPartnerShared.Helpers;
using MySql.Data.MySqlClient;

namespace LingoPartnerInfrastructure.Repository
{
  public class FriendRequestRepository : IFriendRequestRepository
  {
    private readonly string connectionString;

    public FriendRequestRepository(string connectionString)
    {
      this.connectionString = connectionString != null ?
        connectionString :
        InfrastructureHelper.CreateConnectionString();
    }
    public FriendRequest? AddFriendRequest(FriendRequest friendRequest)
    {
      using (MySqlConnection connection = new(connectionString))
      {
        connection.Open();
        using (MySqlTransaction transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
              INSERT INTO FriendRequest (SenderId, RecipientId, Status)
              VALUES (@SenderId, @RecipientId, @Status);
              SELECT LAST_INSERT_ID();";

            using (MySqlCommand command = new(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@SenderId", friendRequest.SenderId);
              command.Parameters.AddWithValue("@RecipientId", friendRequest.RecipientId);
              command.Parameters.AddWithValue("@Status", friendRequest.Status.ToString());

              object result = command.ExecuteScalar();
              if (result != null)
              {
                transaction.Commit();
                return new FriendRequest(
                  Convert.ToInt32(result),
                  friendRequest.SenderId,
                  friendRequest.RecipientId
                );
              }
              else
              {
                transaction.Rollback();
                return null;
              }
            }
          }
          catch (MySqlException ex)
          {
            LoggingHelper.LogError(ex, $"Error adding friend request for sender {friendRequest.SenderId} and recipient {friendRequest.RecipientId}\n {ex.Message}");
          }
        }
      }
      return null;
    }

    public void DeleteFriendRequestById(int friendRequestId)
    {
      using (MySqlConnection connection = new(connectionString))
      {
        connection.Open();
        string query = @"
          DELETE FROM FriendRequest
          WHERE Id = @Id;";

        try
        {
          using (MySqlCommand command = new(query, connection))
          {
            command.Parameters.AddWithValue("@Id", friendRequestId);
            command.ExecuteNonQuery();
          }
        }
        catch (MySqlException ex)
        {
          LoggingHelper.LogError(ex, $"Error deleting friend request with ID {friendRequestId}\n {ex.Message}");
        }
      }
    }

    public FriendRequest? GetFriendRequestById(int friendRequestId)
    {
      using (MySqlConnection connection = new(connectionString))
      {
        connection.Open();
        string query = @"
          SELECT Id, SenderId, RecipientId, Status
          FROM FriendRequest
          WHERE Id = @Id;";

        try
        {
          using (MySqlCommand command = new(query, connection))
          {
            command.Parameters.AddWithValue("@Id", friendRequestId);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
              if (reader.Read())
              {
                return new FriendRequest(
                  reader.GetInt32("Id"),
                  reader.GetInt32("SenderId"),
                  reader.GetInt32("RecipientId")
                );
              }
            }
          }
        }
        catch (MySqlException ex)
        {
          LoggingHelper.LogError(ex, $"Error getting friend request with ID {friendRequestId}\n {ex.Message}");
        }
      }
      return null;
    }

    public List<FriendRequest>? GetFriendRequestsByUserId(int userId)
    {
      using (MySqlConnection connection = new(connectionString))
      {
        connection.Open();
        string query = @"
          SELECT Id, SenderId, RecipientId, Status
          FROM FriendRequest
          WHERE SenderId = @UserId OR RecipientId = @UserId;";

        try
        {
          using (MySqlCommand command = new(query, connection))
          {
            command.Parameters.AddWithValue("@UserId", userId);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
              List<FriendRequest> friendRequests = new();
              while (reader.Read())
              {
                friendRequests.Add(new FriendRequest(
                  reader.GetInt32("Id"),
                  reader.GetInt32("SenderId"),
                  reader.GetInt32("RecipientId")
                ));
              }
              return friendRequests;
            }
          }
        }
        catch (MySqlException ex)
        {
          LoggingHelper.LogError(ex, $"Error getting friend requests for user with ID {userId}\n {ex.Message}");
        }
      }
      return null;
    }

    public void UpdateFriendRequestStatus(int friendRequestId, FriendRequestStatus status)
    {
      using (MySqlConnection connection = new(connectionString))
      {
        connection.Open();
        string query = @"
          UPDATE FriendRequest
          SET Status = @Status
          WHERE Id = @Id;";

        try
        {
          using (MySqlCommand command = new(query, connection))
          {
            command.Parameters.AddWithValue("@Status", status.ToString());
            command.Parameters.AddWithValue("@Id", friendRequestId);
            command.ExecuteNonQuery();
          }
        }
        catch (MySqlException ex)
        {
          LoggingHelper.LogError(ex, $"Error updating friend request with ID {friendRequestId}\n {ex.Message}");
        }
      }
    }

  }
}
