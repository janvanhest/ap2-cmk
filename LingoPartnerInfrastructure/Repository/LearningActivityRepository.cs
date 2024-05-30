using LingoPartnerDomain.interfaces;
using LingoPartnerDomain.classes;
using LingoPartnerDomain.enums;
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

    public LearningActivity? Add(LearningActivity activity)
    {
      using (var connection = new MySqlConnection(_connectionString))
      {
        connection.Open();
        using (var transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
              INSERT INTO LearningActivity (Name, Description, Type, Module_id)
              VALUES (@Name, @Description, @Type, @LearningModuleId);
              SELECT LAST_INSERT_ID();";

            using (var command = new MySqlCommand(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@Name", activity.Name);
              command.Parameters.AddWithValue("@Description", activity.Description);
              command.Parameters.AddWithValue("@Type", activity.Type.ToString());
              command.Parameters.AddWithValue("@LearningModuleId", activity.LearningModuleId);

              var result = command.ExecuteScalar();
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
      }
      return activities;
    }

    public LearningActivity? GetById(int activityId)
    {
      // TODO: Implement this method to get a learning activity from the database
      throw new NotImplementedException();
    }

    public void Remove(int activityId)
    {
      // TODO: Implement this method to remove a learning activity from the database
      throw new NotImplementedException();
    }

    public LearningActivity? Update(LearningActivity activity)
    {
      // TODO: Implement this method to update a learning activity in the database
      throw new NotImplementedException();
    }
  }
}