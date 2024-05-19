using System.Diagnostics;
using LingoPartnerInfrastructure.DTO;
using MySql.Data.MySqlClient;

namespace LingoPartnerInfrastructure
{
  public class UserRepository
  {
    private string ConnectionString;
    public UserRepository()
    {
      // string server = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
      // string database = Environment.GetEnvironmentVariable("DB_NAME") ?? "lp_db";
      // string userName = Environment.GetEnvironmentVariable("DB_USER") ?? "user";
      // string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "password";
      // ConnectionString = $"Server={server};Database={database};User Id={userName};Password={password};";
      ConnectionString = new InfrastructureHelper().CreateConnectionString();
    }
    public UserDTO? AddUser(UserDTO user)
    {
      try
      {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
          string sql = "INSERT INTO Users (FirstName, MiddleName, LastName, DateOfBirth, Email, Password, Username, Role) " +
          "VALUES (@FirstName, @MiddleName, @LastName, @DateOfBirth, @Email, @Password, @Username, @Role); " +
          "SELECT LAST_INSERT_ID();";
          MySqlCommand cmd = new MySqlCommand(sql, connection);
          cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
          cmd.Parameters.AddWithValue("@MiddleName", user.MiddleName);
          cmd.Parameters.AddWithValue("@LastName", user.LastName);
          cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
          cmd.Parameters.AddWithValue("@Email", user.Email);
          cmd.Parameters.AddWithValue("@Password", user.Password);
          cmd.Parameters.AddWithValue("@Username", user.Username);
          cmd.Parameters.AddWithValue("@Role", user.Role);
          connection.Open();
          long id = (long)cmd.ExecuteScalar();
          connection.Close();
          user.Id = (int)id;
          if (id != null)
          {
            return user;
          }
          else
          {
            return null;
          }
        }
      }
      catch (Exception ex)
      {
        Trace.TraceError("An error occurred: {0}", ex);
        throw;
      }
    }
    public List<UserDTO> GetUsers()
    {
      List<UserDTO> users = new List<UserDTO>();
      try
      {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
          connection.Open();
          string sql = "SELECT * FROM lp_db.Users";
          using (MySqlCommand cmd = new MySqlCommand(sql, connection))
          {
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                users.Add(new UserDTO
                {
                  Id = reader.GetInt32("Id"),
                  FirstName = reader.GetString("FirstName"),
                  MiddleName = reader.GetString("MiddleName"),
                  LastName = reader.GetString("LastName"),
                  DateOfBirth = reader.GetDateTime("DateOfBirth"),
                  Email = reader.GetString("Email"),
                  Password = reader.GetString("Password"),
                  Username = reader.GetString("Username"),
                  Role = reader.GetString("Role")
                });
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Trace.TraceError("An error occurred: {0}", ex);
        throw;
      }
      return users;
    }

    public UserDTO GetUser(int id)
    {
      UserDTO user = null;
      try
      {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
          connection.Open();
          string sql = "SELECT * FROM User WHERE Id = @Id";
          using (MySqlCommand cmd = new MySqlCommand(sql, connection))
          {
            cmd.Parameters.AddWithValue("@Id", id);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
              if (reader.Read())
              {
                user = new UserDTO
                {
                  Id = reader.GetInt32("Id"),
                  FirstName = reader.GetString("FirstName"),
                  MiddleName = reader.GetString("MiddleName"),
                  LastName = reader.GetString("LastName"),
                  DateOfBirth = reader.GetDateTime("DateOfBirth"),
                  Email = reader.GetString("Email"),
                  Password = reader.GetString("Password"),
                  Username = reader.GetString("Username"),
                  Role = reader.GetString("Role")
                };
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Trace.TraceError("An error occurred: {0}", ex);

        throw; // Optionally rethrow or handle the exception as needed

      }
      return user;
    }
  }
}