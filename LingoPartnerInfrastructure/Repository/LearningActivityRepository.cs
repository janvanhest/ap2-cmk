using LingoPartnerDomain;
using LingoPartnerDomain.classes;
using LingoPartnerDomain.enums;
using LingoPartnerInfrastructure.Helpers;
using LingoPartnerShared.Helpers;
using MySql.Data.MySqlClient;

namespace LingoPartnerInfrastructure.Repository
{
  public class LearningActivityRepository : ILearningActivityRepository
  {
    private readonly string? _connectionString;
    public LearningActivityRepository(string? connectionString = null)
    {
      _connectionString = connectionString;
    }

    public LearningActivity? AddLearningActivity(LearningActivity activity)
    {
      using (var connection = new MySqlConnection(_connectionString))
      {
        connection.Open();
        using (var transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
              INSERT INTO LearningActivity (Name, Description, Type)
              VALUES (@Name, @Description, @Type);
              SELECT LAST_INSERT_ID();";

            using (var command = new MySqlCommand(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@Name", activity.Name);
              command.Parameters.AddWithValue("@Description", activity.Description);
              command.Parameters.AddWithValue("@Type", activity.Type.ToString());

              var result = command.ExecuteScalar();
              if (result != null)
              {
                transaction.Commit();
                return new LearningActivity(
                    Convert.ToInt32(result),
                    activity.Name,
                    activity.Description,
                    activity.Type
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

    public IEnumerable<LearningActivity> GetAllLearningActivities()
    {
      List<LearningActivity> activities = new List<LearningActivity>();
      using (var connection = new MySqlConnection(_connectionString))
      {
        // TEST: 
        connection.Open();
        string query = "SELECT * FROM LearningActivity";
        using (var cmd = new MySqlCommand(query, connection))
        {
          using (var reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              int id = reader.GetInt32("Id");
              string name = reader.GetString("Name");
              string description = reader.GetString("Description");
              string type = reader.GetString("Type");
              LearningActivityType activityType = (LearningActivityType)Enum.Parse(typeof(LearningActivityType), type);
              activities.Add(new LearningActivity(id, name, description, activityType));
            }
          }
        }
      }
      return activities;
    }

    public LearningActivity? GetLearningActivityById(int activityId)
    {
      // TODO: Implement this method to get a learning activity from the database
      throw new NotImplementedException();
    }

    public void RemoveLearningActivity(int activityId)
    {
      // TODO: Implement this method to remove a learning activity from the database
      throw new NotImplementedException();
    }

    public LearningActivity? UpdateLearningActivity(LearningActivity activity)
    {
      // TODO: Implement this method to update a learning activity in the database
      throw new NotImplementedException();
    }
  }
}