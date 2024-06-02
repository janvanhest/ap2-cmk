// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using dotenv.net;
using LingoPartnerConsole.Helpers;
using LingoPartnerConsole.Views;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerInfrastructure.Helpers;
using LingoPartnerInfrastructure.Repository;

namespace LingoPartnerConsole
{
  internal class Program
  {
    static void Main()
    {
      DotEnv.Load();

      string connectionString = InfrastructureHelper.CreateConnectionString();

      SetupProgram(connectionString);

      var userRepository = new UserRepository(connectionString);
      var learningModuleRepository = new LearningModuleRepository(connectionString);
      var learningActivityRepository = new LearningActivityRepository(connectionString);
      var progressRepository = new ProgressRepository(connectionString);

      // var DashBoardService = new DashBoardService(
      //   userRepository,
      //   learningModuleRepository,
      //   learningActivityRepository,
      //   progressRepository
      //   );

      // Create new administration
      Administration schoolAdministration = new Administration(
        userRepository,
        learningModuleRepository,
        learningActivityRepository,
        progressRepository
      );

      InitializeProgram(schoolAdministration);

      Menu menu = new Menu(
        schoolAdministration
        );
      menu.Show();
    }

    private static void SetupProgram(string connectionString)
    {
      ConfigureTrace();
      if (string.IsNullOrEmpty(connectionString))
      {
        Trace.TraceError("Connection string is null or empty. Exiting...");
        Environment.Exit(0);
      }
      if (!InfrastructureHelper.IsServerAvailable(connectionString))
      {
        Console.WriteLine("Database server is not available. Exiting...");
        Environment.Exit(0);
      }
      if (Environment.GetEnvironmentVariable("ENV") == "development")
      {
        SetupDevelopmentMode();
      }

    }

    private static void InitializeProgram(Administration schoolAdministration)
    {
      Console.Clear();

      DateTime dateTime = DateTime.Now;
      String traceMessage = $"\n\nApplication started at: {dateTime}";
      Trace.TraceInformation(traceMessage);


      ConsoleHelper.DisplayTypingAnimation("\nWelcome to LingoPartner!\n", true);

      Authenticate(schoolAdministration);

      string welcomeMessage = "Welcome Guest!";
      if (schoolAdministration.CurrentUser != null)
      {
        welcomeMessage = $"\nHave a nice schoolday! Or something like that, {schoolAdministration.CurrentUser.getFullName()}!\n";
      }
      Console.WriteLine(welcomeMessage);
      Console.WriteLine("Press a key to continue...\n");
      Console.ReadKey();
    }

    public static void ConfigureTrace(
      string logFilePath = "trace.log",
      bool addConsoleListener = true
      )
    {
      try
      {
        // Create a text file trace listener
        TextWriterTraceListener fileListener = new TextWriterTraceListener(logFilePath);
        Trace.Listeners.Add(fileListener);

        // Optionally, add a console trace listener
        if (addConsoleListener)
        {
          ConsoleTraceListener consoleListener = new ConsoleTraceListener();
          Trace.Listeners.Add(consoleListener);
        }

        // Set the trace level
        Trace.AutoFlush = true;

        Trace.WriteLine("Trace configuration initialized.");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error configuring trace: " + ex.Message);
        // Optionally log the exception or handle it as needed
      }
    }
    private static void SetupDevelopmentMode()
    {
      // TODO: Which things need only to be started in development mode? 
      Console.WriteLine();
      ConsoleHelper.DisplayMessage("Development mode is on", MessageType.SUCCES);
      Console.WriteLine("\nPress a key to continue\n");
      // pres a key to continue
      Console.ReadKey();
    }

    private static void Authenticate(Administration administration)
    {
      while (administration.CurrentUser == null)
      {
        string username = ConsoleHelper.GetStringInput("Enter username: ");
        string? password = ReadPassword();

        if (administration.Authenticate(username, password))
        {
          // successful authentication
          ConsoleHelper.DisplayMessage("Authentication successful", MessageType.SUCCES);
        }
        else
        {
          Console.WriteLine("Authentication failed. Please try again.");
        }
      }
    }

    private static string ReadPassword()
    {
      Console.Write("Enter password:\n");
      string password = string.Empty;
      ConsoleKey key;
      do
      {
        var keyInfo = Console.ReadKey(intercept: true);
        key = keyInfo.Key;

        if (key == ConsoleKey.Backspace && password.Length > 0)
        {
          Console.Write("\b \b");
          password = password[0..^1];
        }
        else if (!char.IsControl(keyInfo.KeyChar))
        {
          Console.Write("*");
          password += keyInfo.KeyChar;
        }
      } while (key != ConsoleKey.Enter);

      Console.WriteLine();
      return password;
    }
  }
}