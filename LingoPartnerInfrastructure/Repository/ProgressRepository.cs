﻿using LingoPartnerDomain.classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.interfaces;
using LingoPartnerShared.Helpers;
using MySql.Data.MySqlClient;

namespace LingoPartnerInfrastructure.Repository
{
  public class ProgressRepository : IProgressRepository
  {
    private readonly string _connectionString;

    public ProgressRepository(string connectionString)
    {
      _connectionString = connectionString;
    }

    public Progress? AddProgress(Progress progress)
    {
      using (var connection = new MySqlConnection(_connectionString))
      {
        connection.Open();
        using (var transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
                            INSERT INTO Progress (Type, Status, Details, UserId, LearningActivityId)
                            VALUES (@Type, @Status, @Details, @UserId, @LearningActivityId);
                            SELECT LAST_INSERT_ID();";

            using (var command = new MySqlCommand(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@Type", progress.Type.ToString());
              command.Parameters.AddWithValue("@Status", progress.Status.ToString());
              command.Parameters.AddWithValue("@Details", progress.Details);
              command.Parameters.AddWithValue("@UserId", progress.UserId);
              command.Parameters.AddWithValue("@LearningActivityId", progress.LearningActivityId);

              var result = command.ExecuteScalar();
              if (result != null)
              {
                transaction.Commit();
                return new Progress(
                    Convert.ToInt32(result),
                    progress.Type,
                    progress.Status,
                    progress.Details,
                    progress.UserId,
                    progress.LearningActivityId
                );
              }
            }
          }
          catch (MySqlException ex)
          {
            LoggingHelper.LogError(ex, ex.Message);
            transaction.Rollback();
          }
        }
      }
      return null;
    }

    public IEnumerable<Progress> GetProgressByUserId(int userId)
    {
      using (var connection = new MySqlConnection(_connectionString))
      {
        connection.Open();
        string query = @"SELECT * FROM Progress WHERE UserId = @UserId";
        using (var command = new MySqlCommand(query, connection))
        {
          command.Parameters.AddWithValue("@UserId", userId);
          using (var reader = command.ExecuteReader())
          {
            List<Progress> progressList = new List<Progress>();
            while (reader.Read())
            {
              progressList.Add(new Progress(
                  reader.GetInt32("Id"),
                  Enum.Parse<ProgressType>(reader.GetString("Type")),
                  Enum.Parse<ProgressStatus>(reader.GetString("Status")),
                  reader.GetString("Details"),
                  reader.GetInt32("UserId"),
                  reader.GetInt32("LearningActivityId")
              ));
            }
            return progressList;
          }
        }
      }
    }

    public Progress? UpdateProgress(Progress updateProgress)
    {
      using (var connection = new MySqlConnection(_connectionString))
      {
        connection.Open();
        using (var transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
                            UPDATE Progress 
                            SET Status = @Status, Details = @Details 
                            WHERE Id = @Id";

            using (var command = new MySqlCommand(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@Status", updateProgress.Status.ToString());
              command.Parameters.AddWithValue("@Details", updateProgress.Details);
              command.Parameters.AddWithValue("@Id", updateProgress.Id);

              var result = command.ExecuteNonQuery();
              if (result > 0)
              {
                transaction.Commit();
                return updateProgress;
              }
            }
          }
          catch (MySqlException ex)
          {
            LoggingHelper.LogError(ex, ex.Message);
            transaction.Rollback();
          }
        }
      }
      return null;
    }
  }
}
