﻿using MySql.Data.MySqlClient;

namespace LingoPartnerInfrastructure.Helpers
{
  public class InfrastructureHelper
  {
    public static string CreateConnectionString()
    {
      string server = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
      string database = Environment.GetEnvironmentVariable("DB_NAME") ?? "lp_db";
      string userName = Environment.GetEnvironmentVariable("DB_USER") ?? "user";
      string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "password";
      string connectionString = $"Server={server};Database={database};User Id={userName};Password={password};";
      return connectionString;
    }
    public static bool IsServerAvailable(string connectionString)
    {
      try
      {
        using (MySqlConnection connection = new(connectionString))
        {
          connection.Open();
          return true;
        }
      }
      catch (MySqlException)
      {
        return false;
      }
    }
  }
}