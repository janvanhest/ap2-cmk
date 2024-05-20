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
      ConfigureTrace();
      if (!InfrastructureHelper.IsServerAvailable())
      {
        Console.WriteLine("Database server is not available. Exiting...");
        Environment.Exit(0);
      }
      if (Environment.GetEnvironmentVariable("ENV") == "development")
      {
        SetupDevelopmentMode();
      }
      FirstWelcomeMessage();

      UserRepository userRepository = new UserRepository();
      LearningModuleRepository learningModuleRepository = new LearningModuleRepository();

      // Create new administration
      Administration schoolAdministration = new Administration(
        userRepository,
        learningModuleRepository
      );
      Menu menu = new Menu(schoolAdministration);
      menu.Show();
    }

    private static void FirstWelcomeMessage()
    {
      Console.Clear();
      DateTime dateTime = DateTime.Now;
      String traceMessage = $"\n\nApplication started at: {dateTime}";
      Trace.TraceInformation(traceMessage);

      Console.WriteLine("Welcome to LingoPartner!\n");
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