// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using dotenv.net;
using LingoPartnerConsole.Helpers;
using LingoPartnerConsole.Views;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerInfrastructure.Helpers;
using LingoPartnerInfrastructure.Repository;
using LingoPartnerDomain.Services;
using LingoPartnerDomain.Interfaces.Strategies;
using LingoPartnerDomain.Strategies;
using LingoPartnerDomain.Strategies.Scoring;

namespace LingoPartnerConsole
{
  internal class Program
  {
    static void Main()
    {
      // Create a new DotEnv object to load the .env file
      DotEnv.Load();

      // Create a connection string from the environment variables
      string connectionString = InfrastructureHelper.CreateConnectionString();

      // Does  a few basic routines like setting up the trace and checking if the database is available
      SetupProgram(connectionString);

      // Create a new ServiceCollection and configure the services
      ServiceCollection serviceCollection = new();
      ConfigureServices(serviceCollection, connectionString);
      ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

      // Authenticate the user
      IAuthenticationService authenticationService = serviceProvider.GetService<IAuthenticationService>() ?? throw new InvalidOperationException("fail to get authentication service running");
      AuthenticationHelper.Authenticate(authenticationService);

      // Initialize the program, does some basic routines like authentication, set the user and displaying a welcome message
      InitializeProgram(authenticationService);

      // Create a new Menu object and show the menu
      ILearningStreakService learningStreakService =
        serviceProvider.GetService<ILearningStreakService>() ?? throw new InvalidOperationException("fail to get learning streak service running");
      ILearningModuleService learningModuleService =
        serviceProvider.GetService<ILearningModuleService>() ?? throw new InvalidOperationException("fail to get learning module service running");
      IUserService userService =
        serviceProvider.GetService<IUserService>() ?? throw new InvalidOperationException("fail to get user service running");
      ILearningActivityService learningActivityService =
        serviceProvider.GetService<ILearningActivityService>() ?? throw new InvalidOperationException("fail to get learning activity service running");
      IProgressService progressService =
        serviceProvider.GetService<IProgressService>() ?? throw new InvalidOperationException("fail to get progress service running");

      Menu menu = new(
        learningStreakService,
        learningModuleService,
        authenticationService,
        userService,
        learningActivityService,
        progressService
        );
      menu.Show();
    }

    private static void ConfigureServices(IServiceCollection services, string connectionString)
    {
      // Add Repositories to the services
      services.AddScoped<IUserRepository>(provider => new UserRepository(connectionString));
      services.AddScoped<ILearningModuleRepository>(provider => new LearningModuleRepository(connectionString));
      services.AddScoped<ILearningActivityRepository>(provider => new LearningActivityRepository(connectionString));
      services.AddScoped<IProgressRepository>(provider => new ProgressRepository(connectionString));
      // Add Services to the services
      services.AddScoped<ILearningStreakService, LearningStreakService>();
      services.AddScoped<ILearningModuleService, LearningModuleService>();
      services.AddSingleton<IAuthenticationService, AuthenticationService>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<ILearningActivityService, LearningActivityService>();
      services.AddScoped<IProgressService, ProgressService>();
      // Add strategies to the services
      services.AddScoped<ILearningStreakStrategy, ConsecutiveDaysStrategy>();
      services.AddScoped<ILearningStreakStrategy, WeekendSkipStrategy>();
      services.AddScoped<ILearningStreakScoringStrategy, SimpleScoringStrategy>();
      services.AddScoped<ILearningStreakScoringStrategy, BonusScoringStrategy>();
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
    private static void InitializeProgram(IAuthenticationService authenticationService)
    {
      User? user = authenticationService.CurrentUser;
      Console.Clear();

      DateTime dateTime = DateTime.Now;
      string traceMessage = $"\n\nApplication started at: {dateTime}";
      Trace.TraceInformation(traceMessage);


      ConsoleHelper.DisplayTypingAnimation("\nWelcome to LingoPartner!\n", true);

      string welcomeMessage = "Welcome Guest!";
      if (user != null)
      {
        welcomeMessage = $"\nHave a nice schoolday! Or something like that, {user.GetFullName()}!\n";
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
        TextWriterTraceListener fileListener = new TextWriterTraceListener(logFilePath);
        Trace.Listeners.Add(fileListener);

        if (addConsoleListener)
        {
          ConsoleTraceListener consoleListener = new ConsoleTraceListener();
          Trace.Listeners.Add(consoleListener);
        }
        // Set the trace level
        Trace.AutoFlush = true;
        // Woohoo! We're done!
        Trace.WriteLine("Trace configuration initialized.");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error configuring trace: " + ex.Message);
      }
    }
    private static void SetupDevelopmentMode()
    {
      // FIXME: Which things need only to be started in development mode? 
      Console.WriteLine();
      ConsoleHelper.DisplayMessage("Development mode is on", MessageType.SUCCES);
      Console.WriteLine("\nPress a key to continue\n");
      Console.ReadKey();
    }
  }
}