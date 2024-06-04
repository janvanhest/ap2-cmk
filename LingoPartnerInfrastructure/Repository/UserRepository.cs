using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerInfrastructure.Helpers;
using LingoPartnerShared.Helpers;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Net.Mail;

namespace LingoPartnerInfrastructure.Repository
{
  public class UserRepository : IUserRepository
  {
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
      _connectionString = connectionString != null ?
        connectionString :
        InfrastructureHelper.CreateConnectionString();
    }
    public User? AddUser(User user)
    {
      using (var connection = new MySqlConnection(_connectionString))
      {
        connection.Open();
        using (var transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
              INSERT INTO User (FirstName, MiddleName, LastName, DateOfBirth, Email, Password, Username, Role)
              VALUES (@FirstName, @MiddleName, @LastName, @DateOfBirth, @Email, @Password, @Username, @Role);
              SELECT LAST_INSERT_ID();";

            using (var command = new MySqlCommand(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@FirstName", user.FirstName);
              command.Parameters.AddWithValue("@MiddleName", user.MiddleName);
              command.Parameters.AddWithValue("@LastName", user.LastName);
              command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
              command.Parameters.AddWithValue("@Email", user.Email.ToString());
              command.Parameters.AddWithValue("@Password", user.Password); // Consider using hashed password
              command.Parameters.AddWithValue("@Username", user.Username);
              command.Parameters.AddWithValue("@Role", user.Role.ToString());

              var result = command.ExecuteScalar();
              if (result != null)
              {
                transaction.Commit();
                return new User(
                    Convert.ToInt32(result),
                    user.FirstName,
                    user.MiddleName,
                    user.LastName,
                    user.DateOfBirth,
                    user.Email,
                    user.Password,
                    user.Username,
                    user.Role
                );
              }
            }
          }
          catch (MySqlException ex)
          {
            transaction.Rollback();
            Trace.TraceError($"Database error: {ex.Message}");
            throw;
          }
        }
      }
      return null;
    }

    public User? GetUserByUsername(string username)
    {
      using (var connection = new MySqlConnection(_connectionString))
      {
        connection.Open();
        string query = "SELECT * FROM User WHERE Username = @Username";
        using (var cmd = new MySqlCommand(query, connection))
        {
          cmd.Parameters.AddWithValue("@Username", username);
          using (var reader = cmd.ExecuteReader())
          {
            if (reader.Read())
            {
              return new User(
                  reader.GetInt32("Id"),
                  reader.GetString("FirstName"),
                  reader.GetString("MiddleName"),
                  reader.GetString("LastName"),
                  reader.GetDateTime("DateOfBirth"),
                  new MailAddress(reader.GetString("Email")),
                  reader.GetString("Password"),
                  reader.GetString("Username"),
                  Enum.Parse<UserRole>(reader.GetString("Role"))
              );
            }
          }
        }
      }
      return null;
    }

    public IEnumerable<User> GetUsers()
    {
      var users = new List<User>();
      using (var connection = new MySqlConnection(_connectionString))
      {
        connection.Open();
        string query = "SELECT * FROM User";
        using (var cmd = new MySqlCommand(query, connection))
        {
          using (var reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              users.Add(new User(
                  reader.GetInt32("Id"),
                  reader.GetString("FirstName"),
                  reader.GetString("MiddleName"),
                  reader.GetString("LastName"),
                  reader.GetDateTime("DateOfBirth"),
                  new MailAddress(reader.GetString("Email")),
                  reader.GetString("Password"),
                  reader.GetString("Username"),
                  Enum.Parse<UserRole>(reader.GetString("Role"))
              ));
            }
          }
        }
      }
      return users;
    }

    public User? UpdateUser(User user)
    {
      using (var connection = new MySqlConnection(_connectionString))
      {
        connection.Open();
        using (var transaction = connection.BeginTransaction())
        {
          try
          {
            string query = @"
              UPDATE User
              SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, DateOfBirth = @DateOfBirth, Email = @Email, Password = @Password, Username = @Username, Role = @Role
              WHERE Id = @Id;";

            using (var command = new MySqlCommand(query, connection, transaction))
            {
              command.Parameters.AddWithValue("@Id", user.Id);
              command.Parameters.AddWithValue("@FirstName", user.FirstName);
              command.Parameters.AddWithValue("@MiddleName", user.MiddleName);
              command.Parameters.AddWithValue("@LastName", user.LastName);
              command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
              command.Parameters.AddWithValue("@Email", user.Email.ToString());
              command.Parameters.AddWithValue("@Password", user.Password); // Consider using hashed password
              command.Parameters.AddWithValue("@Username", user.Username);
              command.Parameters.AddWithValue("@Role", user.Role.ToString());

              var result = command.ExecuteNonQuery();
              if (result > 0)
              {
                transaction.Commit();
                return user;
              }
            }
          }
          catch (MySqlException ex)
          {
            transaction.Rollback();
            LoggingHelper.LogError(ex, "Database error.");
            throw;
          }
        }
      }
      return null;
    }
  }
}