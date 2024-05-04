using LingoPartnerInfrastructure.DTO;
using MySql.Data.MySqlClient;

namespace LingoPartnerInfrastructure
{
  public class UserRepository
  {
    private string ConnectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
    public UserRepository()
    {

      string server = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
      Console.WriteLine(server);
      string database = Environment.GetEnvironmentVariable("DB_NAME") ?? "lingo_partner";
      Console.WriteLine(database);
      string userName = Environment.GetEnvironmentVariable("DB_USER") ?? "user";
      Console.WriteLine(userName);
      string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "pwd";
      Console.WriteLine(password);
      ConnectionString = $"Server={server};Database={database};User Id={userName};Password={password};";
      Console.WriteLine(ConnectionString);
    }
    public void AddUser(UserDTO user)
    {
      try
      {
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
          string sql = "INSERT INTO Users (FirstName, MiddleName, LastName, DateOfBirth, Email, Password, Username, Role) VALUES (@FirstName, @MiddleName, @LastName, @DateOfBirth, @Email, @Password, @Username, @Role)";
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
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
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
          string sql = "SELECT * FROM User";
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
        Console.WriteLine(ex.Message);
        // Optionally rethrow or handle the exception as needed
      }
      return users;
    }
  }
}