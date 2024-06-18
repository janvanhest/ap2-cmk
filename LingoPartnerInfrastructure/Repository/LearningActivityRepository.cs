using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerShared.Helpers;
using MySql.Data.MySqlClient;
using LingoPartnerDomain.Interfaces.Repositories;

namespace LingoPartnerInfrastructure.Repository
{
  public class LearningActivityRepository : ILearningActivityRepository
  {
    private readonly string? _connectionString;
    public LearningActivityRepository(string? connectionString = null)
    {
      _connectionString = connectionString;
    }

    public LearningActivity? Add(LearningActivity activity)
    {
      using (MySqlConnection connection = new(_connectionString))
      {
        connection.Open();
        using (MySqlTransaction transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
              INSERT INTO LearningActivity (Name, Description, Type, Module_id)
              VALUES (@Name, @Description, @Type, @LearningModuleId);
              SELECT LAST_INSERT_ID();";

            using (MySqlCommand command = new(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@Name", activity.Name);
              command.Parameters.AddWithValue("@Description", activity.Description);
              command.Parameters.AddWithValue("@Type", activity.Type.ToString());
              command.Parameters.AddWithValue("@LearningModuleId", activity.LearningModuleId);

              object result = command.ExecuteScalar();
              if (result != null)
              {
                transaction.Commit();
                return new LearningActivity(
                    Convert.ToInt32(result),
                    activity.Name,
                    activity.Description,
                    activity.Type,
                    activity.LearningModuleId
                );
              }
            }
          }
          catch (MySqlException ex)
          {
            LoggingHelper.LogError(ex, "Error adding learning activity");
            throw;
          }
        }
      }
      return null;
    }

    public IEnumerable<LearningActivity> GetAll()
    {
      List<LearningActivity> activities = [];
      using (MySqlConnection connection = new(_connectionString))
      {
        // TEST: 
        connection.Open();
        string query = "SELECT * FROM LearningActivity";
        using (MySqlCommand cmd = new MySqlCommand(query, connection))
        {
          try
          {
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                LearningActivity activity = new(
                  (int)reader.GetInt32("Id"),
                  reader.GetString("Name"),
                  reader.GetString("Description"),
                  (LearningActivityType)Enum.Parse(typeof(LearningActivityType), reader.GetString("Type")),
                  (int)reader.GetInt32("Module_id")
                );
                activities.Add(activity);
              }
            }
          }
          catch (MySqlException ex)
          {
            LoggingHelper.LogError(ex, "Error getting all learning activities");
            throw;
          }

        }
      }
      return activities;
    }

    public LearningActivity? GetById(int activityId)
    {
      // TODO: Implement this method to get a learning activity from the database
      LearningActivity? activity = null;
      using (MySqlConnection connection = new(_connectionString))
      {
        connection.Open();
        string query = "SELECT * FROM LearningActivity WHERE Id = @Id";
        using (MySqlCommand cmd = new MySqlCommand(query, connection))
        {
          cmd.Parameters.AddWithValue("@Id", activityId);
          try
          {
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
              if (reader.Read())
              {
                activity = new LearningActivity(
                  (int)reader.GetInt32("Id"),
                  reader.GetString("Name"),
                  reader.GetString("Description"),
                  (LearningActivityType)Enum.Parse(typeof(LearningActivityType), reader.GetString("Type")),
                  (int)reader.GetInt32("Module_id")
                );
              }
            }
          }
          catch (MySqlException ex)
          {
            LoggingHelper.LogError(ex, "Error getting learning activity by id");
            throw;
          }
        }
        return activity;
      }
    }

    public IEnumerable<LearningActivity> GetByIds(IEnumerable<int> activityIds)
    {
      if (activityIds == null || !activityIds.Any())
      {
        throw new ArgumentException("Activity IDs must not be null or empty", nameof(activityIds));
      }

      var activities = new List<LearningActivity>();
      using (var connection = new MySqlConnection(_connectionString))
      {
        connection.Open();
        var query = $"SELECT * FROM LearningActivity WHERE Id IN ({string.Join(",", activityIds.Select((_, i) => $"@Id{i}"))})";

        using (var cmd = new MySqlCommand(query, connection))
        {
          for (int i = 0; i < activityIds.Count(); i++)
          {
            cmd.Parameters.AddWithValue($"@Id{i}", activityIds.ElementAt(i));
          }

          using (var reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              var activity = new LearningActivity(
                  reader.GetInt32("Id"),
                  reader.GetString("NAME"),
                  reader.GetString("Description"),
                  (LearningActivityType)Enum.Parse(typeof(LearningActivityType), reader.GetString("TYPE")),
                  reader.GetInt32("Module_id")
              );
              activities.Add(activity);
            }
          }
        }
      }
      return activities;
    }

    public IEnumerable<LearningActivity> GetByLearningModuleId(int moduleId)
    {
      List<LearningActivity> activities = [];

      using (MySqlConnection connection = new(_connectionString))
      {
        connection.Open();
        string query = "SELECT * FROM LearningActivity WHERE Module_id = @ModuleId";
        using (MySqlCommand cmd = new MySqlCommand(query, connection))
        {
          cmd.Parameters.AddWithValue("@ModuleId", moduleId);
          try
          {
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                LearningActivity activity = new(
                  (int)reader.GetInt32("Id"),
                  reader.GetString("Name"),
                  reader.GetString("Description"),
                  (LearningActivityType)Enum.Parse(typeof(LearningActivityType), reader.GetString("Type")),
                  (int)reader.GetInt32("Module_id")
                );
                activities.Add(activity);
              }
            }
          }
          catch (MySqlException ex)
          {
            LoggingHelper.LogError(ex, "Error getting learning activity by learning module id");
            throw;
          }
        }
      }
      return activities;
    }


    public void Remove(int activityId)
    {
      // TODO: Implement this method to remove a learning activity from the database
      using (MySqlConnection connection = new(_connectionString))
      {
        connection.Open();
        string query = "DELETE FROM LearningActivity WHERE Id = @Id";
        try
        {
          using (MySqlCommand cmd = new MySqlCommand(query, connection))
          {
            cmd.Parameters.AddWithValue("@Id", activityId);
            cmd.ExecuteNonQuery();
          }
        }
        catch (MySqlException ex)
        {
          LoggingHelper.LogError(ex, "Error deleting learning activity");
          throw;
        }

      }
    }

    public LearningActivity? Update(LearningActivity activity)
    {
      LearningActivity? updatedActivity = null;
      using (MySqlConnection connection = new(_connectionString))
      {
        connection.Open();
        using (MySqlTransaction transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
              UPDATE LearningActivity
              SET Name = @Name, Description = @Description, Type = @Type, Module_id = @LearningModuleId
              WHERE Id = @Id";

            using (MySqlCommand command = new(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@Id", activity.Id);
              command.Parameters.AddWithValue("@Name", activity.Name);
              command.Parameters.AddWithValue("@Description", activity.Description);
              command.Parameters.AddWithValue("@Type", activity.Type.ToString());
              command.Parameters.AddWithValue("@LearningModuleId", activity.LearningModuleId);

              int result = command.ExecuteNonQuery();
              if (result > 0)
              {
                transaction.Commit();
                updatedActivity = new LearningActivity(
                    activity.Id,
                    activity.Name,
                    activity.Description,
                    activity.Type,
                    activity.LearningModuleId
                );
              }
            }
          }
          catch (MySqlException ex)
          {
            LoggingHelper.LogError(ex, "Error updating learning activity");
            throw;
          }
        }
      }
      return updatedActivity;
    }
  }
}