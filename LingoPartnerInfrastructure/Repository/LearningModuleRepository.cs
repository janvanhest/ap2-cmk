using System.Diagnostics;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerInfrastructure.Helpers;
using LingoPartnerShared.Helpers;
using MySql.Data.MySqlClient;

namespace LingoPartnerInfrastructure.Repository
{
  public class LearningModuleRepository : ILearningModuleRepository
  {
    LearningModule? learningModule = null;
    private readonly string? connectionString;
    public LearningModuleRepository(string? connectionString = null)
    {
      this.connectionString = connectionString ?? InfrastructureHelper.CreateConnectionString();
    }
    public LearningModule? AddLearningModule(LearningModule module)
    {
      using (MySqlConnection connection = new(connectionString))
      {
        connection.Open();
        using (MySqlTransaction transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
              INSERT INTO LearningModule (Name, Description)
              VALUES (@Name, @Description);
              SELECT LAST_INSERT_ID();";

            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@Name", module.Name);
              command.Parameters.AddWithValue("@Description", module.Description);

              object result = command.ExecuteScalar();
              if (result != null)
              {
                transaction.Commit();
                learningModule = new LearningModule(
                    Convert.ToInt32(result),
                    module.Name,
                    module.Description
                );
                return learningModule;
              }
            }
          }
          catch (MySqlException ex)
          {
            LoggingHelper.LogError(ex, "Error adding learning module");
            throw;
          }
        }
      }
      return learningModule;
    }

    public IEnumerable<LearningModule> GetAllLearningModules()
    {
      List<LearningModule> learningModules = new List<LearningModule>();
      try
      {
        using (MySqlConnection connection = new(connectionString))
        {
          connection.Open();
          string query = "SELECT * FROM LearningModule";
          using (MySqlCommand command = new(query, connection))
          {
            using (MySqlDataReader reader = command.ExecuteReader())
            {
              while (reader.Read())
              {
                LearningModule newLearningModule = new(
                    reader.GetInt32("Id"),
                    reader.GetString("Name"),
                    reader.GetString("Description")
                );
                learningModules.Add(newLearningModule);
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        // Log the exception (replace with your actual logging mechanism)
        Console.WriteLine($"An error occurred: {ex.Message}");
        Trace.TraceError($"An error occurred: {ex.Message}");
        throw;
      }
      return learningModules;
    }

    public LearningModule? GetLearningModuleById(int id)
    {
      LearningModule? learningModule = null;
      try
      {
        using (MySqlConnection connection = new(connectionString))
        {
          connection.Open();
          string query = "SELECT * FROM LearningModule WHERE Id = @Id";
          using (MySqlCommand command = new(query, connection))
          {
            command.Parameters.AddWithValue("@Id", id);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
              if (reader.Read())
              {
                learningModule = new LearningModule(
                    reader.GetInt32("Id"),
                    reader.GetString("Name"),
                    reader.GetString("Description")
                );
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        LoggingHelper.LogError(ex, "Error getting learning module by id");
        throw;
      }
      return learningModule;
    }

    public LearningModule? UpdateLearningModule(LearningModule updatedModule)
    {
      LearningModule? updatedLearningModule = null;
      using (MySqlConnection connection = new(connectionString))
      {
        connection.Open();
        using (MySqlTransaction transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
              UPDATE LearningModule
              SET Name = @Name, Description = @Description
              WHERE Id = @Id;
              SELECT * FROM LearningModule WHERE Id = @Id;";

            using (MySqlCommand command = new(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@Id", updatedModule.Id);
              command.Parameters.AddWithValue("@Name", updatedModule.Name);
              command.Parameters.AddWithValue("@Description", updatedModule.Description);

              using (MySqlDataReader reader = command.ExecuteReader())
              {
                if (reader.Read())
                {
                  updatedLearningModule = new LearningModule(
                      reader.GetInt32("Id"),
                      reader.GetString("Name"),
                      reader.GetString("Description")
                  );
                }
              }
            }
          }
          catch (MySqlException ex)
          {
            LoggingHelper.LogError(ex, "Error updating learning module");
            throw;
          }
        }
      }
      return updatedLearningModule;
    }

    public bool DeleteLearningModule(int id)
    {
      bool updateSuccess = false;
      using (MySqlConnection connection = new(connectionString))
      {
        connection.Open();
        using (MySqlTransaction transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
              DELETE FROM LearningModule
              WHERE Id = @Id;";

            using (MySqlCommand command = new(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@Id", id);

              int result = command.ExecuteNonQuery();
              if (result > 0)
              {
                transaction.Commit();
                updateSuccess = true;
              }
            }
          }
          catch (MySqlException ex)
          {
            LoggingHelper.LogError(ex, "Error deleting learning module");
            throw;
          }
        }
      }
      return updateSuccess;
    }

    public List<LearningModule> GetLearningModulesByIds(IEnumerable<int> ids)
    {
      if (ids == null || !ids.Any())
      {
        throw new ArgumentException("IDs must not be null or empty", nameof(ids));
      }

      var learningModules = new List<LearningModule>();
      using (var connection = new MySqlConnection(connectionString))
      {
        connection.Open();
        // Build the query dynamically with parameter placeholders
        string query = "SELECT * FROM LearningModule WHERE Id IN (" + string.Join(",", ids.Select((_, i) => $"@Id{i}")) + ")";

        using (var command = new MySqlCommand(query, connection))
        {
          // Add each ID as a separate parameter
          for (int i = 0; i < ids.Count(); i++)
          {
            command.Parameters.AddWithValue($"@Id{i}", ids.ElementAt(i));
          }

          using (var reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              var newLearningModule = new LearningModule(
                  reader.GetInt32("Id"),
                  reader.GetString("Name"),
                  reader.GetString("Description")
              );
              learningModules.Add(newLearningModule);
            }
          }
        }
      }
      return learningModules;
    }

  }
}

