// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using dotenv.net;

using LingoPartnerConsole.Views;
using LingoPartnerDomain.classes;
using LingoPartnerInfrastructure.Helpers;
using LingoPartnerInfrastructure.Repository;

namespace LingoPartnerApp
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

      // Create new administration
      Administration schoolAdministration = new Administration(
        userRepository,
        learningModuleRepository,
        learningActivityRepository
      );

      schoolAdministration.Initialize();
      FirstWelcomeMessage(schoolAdministration);

      Menu menu = new Menu(schoolAdministration);
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

    private static void FirstWelcomeMessage(Administration schoolAdministration)
    {
      Console.Clear();
      DateTime dateTime = DateTime.Now;
      String traceMessage = $"\n\nApplication started at: {dateTime}";
      Trace.TraceInformation(traceMessage);

      Console.WriteLine("Welcome to LingoPartner!\n");

      if (schoolAdministration.CurrentUser != null)
      {
        Console.WriteLine($"Welcome, {schoolAdministration.CurrentUser.getFullName()}!");
      }
      else
      {
        Console.WriteLine("Welcome, guest!");
      }

      Console.WriteLine("Press a key to continue...\n");
      Console.ReadKey();
    }

    private static void ConfigureTrace()
    {
      // Create a text file trace listener
      TextWriterTraceListener fileListener = new TextWriterTraceListener("trace.log");
      Trace.Listeners.Add(fileListener);

      // Optionally, add a console trace listener
      ConsoleTraceListener consoleListener = new ConsoleTraceListener();
      Trace.Listeners.Add(consoleListener);

      // Set the trace level
      Trace.AutoFlush = true;
    }
    private static void SetupDevelopmentMode()
    {
      // TODO: Which things need only to be started in development mode? 
      Console.WriteLine("\n===========================");
      Console.WriteLine("Running in development mode");
      Console.WriteLine("===========================");
      Console.WriteLine("\nPress a key to continue");
      // pres a key to continue
      Console.ReadKey();
    }
  }
}