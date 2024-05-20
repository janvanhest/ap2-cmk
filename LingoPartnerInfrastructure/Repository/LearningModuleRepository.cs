using System.Diagnostics;
using LingoPartnerDomain.classes;
using LingoPartnerDomain.Interfaces;
using LingoPartnerInfrastructure.Helpers;
using LingoPartnerShared.Helpers;
using MySql.Data.MySqlClient;

namespace LingoPartnerInfrastructure.Repository
{
  public class LearningModuleRepository : ILearningModuleRepository
  {
    private readonly string _connectionString;
    public LearningModuleRepository(string? connectionString = null)
    {
      _connectionString = connectionString ?? InfrastructureHelper.CreateConnectionString()
          ?? throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty.");
    }
    public LearningModule? AddLearningModule(LearningModule module)
    {
      using (var connection = new MySqlConnection(_connectionString))
      {
        connection.Open();
        using (var transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
              INSERT INTO LearningModule (Name, Description)
              VALUES (@Name, @Description);
              SELECT LAST_INSERT_ID();";

            using (var command = new MySqlCommand(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@Name", module.Name);
              command.Parameters.AddWithValue("@Description", module.Description);

              var result = command.ExecuteScalar();
              if (result != null)
              {
                transaction.Commit();
                return new LearningModule(
                    Convert.ToInt32(result),
                    module.Name,
                    module.Description
                );
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
      return null;
    }

    public IEnumerable<LearningModule> GetAllLearningModules()
    {
      List<LearningModule> learningModules = new List<LearningModule>();
      try
      {
        using (var connection = new MySqlConnection(_connectionString))
        {
          connection.Open();
          string query = "SELECT * FROM LearningModule";
          using (var command = new MySqlCommand(query, connection))
          {
            using (var reader = command.ExecuteReader())
            {
              while (reader.Read())
              {
                LearningModule newLearningModule = new LearningModule(
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
  }
}

