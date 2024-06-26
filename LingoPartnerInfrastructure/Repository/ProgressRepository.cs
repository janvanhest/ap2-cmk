﻿using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Repositories;
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
      using (MySqlConnection connection = new(_connectionString))
      {
        connection.Open();
        using (MySqlTransaction transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
                            INSERT INTO Progress (Type, Status, Details, UserId, LearningActivityId)
                            VALUES (@Type, @Status, @Details, @UserId, @LearningActivityId);
                            SELECT LAST_INSERT_ID();";

            using (MySqlCommand command = new(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@Type", progress.Type.ToString());
              command.Parameters.AddWithValue("@Status", progress.Status.ToString());
              command.Parameters.AddWithValue("@Details", progress.Details);
              command.Parameters.AddWithValue("@UserId", progress.UserId);
              command.Parameters.AddWithValue("@LearningActivityId", progress.LearningActivityId);

              object result = command.ExecuteScalar();
              if (result != null)
              {
                transaction.Commit();
                return new Progress(
                    Convert.ToInt32(result),
                    progress.Type,
                    progress.Status,
                    progress.Details,
                    progress.UserId,
                    progress.LearningActivityId,
                    progress.Date
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

    public IEnumerable<Progress> GetAllProgress()
    {
      using (MySqlConnection connection = new(_connectionString))
      {
        connection.Open();
        string query = @"SELECT * FROM Progress";
        using (MySqlCommand command = new(query, connection))
        {
          using (MySqlDataReader reader = command.ExecuteReader())
          {
            List<Progress> progressList = [];
            while (reader.Read())
            {
              progressList.Add(new Progress(
                  reader.GetInt32("Id"),
                  Enum.Parse<ProgressType>(reader.GetString("Type")),
                  Enum.Parse<ProgressStatus>(reader.GetString("Status")),
                  reader.GetString("Details"),
                  reader.GetInt32("UserId"),
                  reader.GetInt32("LearningActivityId"),
                  reader.GetDateTime("Date")
              ));
            }
            return progressList;
          }
        }
      }
    }

    public IEnumerable<Progress> GetProgressByUserId(int userId)
    {
      using (MySqlConnection connection = new(_connectionString))
      {
        connection.Open();
        string query = @"SELECT * FROM Progress WHERE user_id = @UserId";
        using (MySqlCommand command = new(query, connection))
        {
          command.Parameters.AddWithValue("@UserId", userId);
          using (MySqlDataReader reader = command.ExecuteReader())
          {
            List<Progress> progressList = [];
            while (reader.Read())
            {
              progressList.Add(new Progress(
                  reader.GetInt32("id"),
                  Enum.Parse<ProgressType>(reader.GetString("progress_type")),
                  Enum.Parse<ProgressStatus>(reader.GetString("status")),
                  reader.GetString("details"),
                  reader.GetInt32("user_id"),
                  reader.GetInt32("learningActivity_id"),
                  reader.GetDateTime("date")
              ));
            }
            return progressList;
          }
        }
      }
    }

    public IEnumerable<DateTime> GetUniqueDatesByUserId(int userId)
    {
      List<DateTime> uniqueDates = [];
      using (MySqlConnection connection = new(_connectionString))
      {
        connection.Open();
        string query = @"SELECT DISTINCT Date FROM Progress WHERE UserId = @UserId";
        using (MySqlCommand command = new(query, connection))
        {
          command.Parameters.AddWithValue("@UserId", userId);
          using (MySqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              uniqueDates.Add(reader.GetDateTime("Date"));
            }
          }
        }
      }
      return uniqueDates;
    }

    public Progress? UpdateProgress(Progress updateProgress)
    {
      using (MySqlConnection connection = new(_connectionString))
      {
        connection.Open();
        using (MySqlTransaction transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
                            UPDATE Progress 
                            SET Status = @Status, Details = @Details 
                            WHERE Id = @Id";

            using (MySqlCommand command = new(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@Status", updateProgress.Status.ToString());
              command.Parameters.AddWithValue("@Details", updateProgress.Details);
              command.Parameters.AddWithValue("@Id", updateProgress.Id);

              int result = command.ExecuteNonQuery();
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
