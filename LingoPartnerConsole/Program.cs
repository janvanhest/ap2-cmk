// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using dotenv.net;
using LingoPartnerConsole.Views;

using LingoPartnerDomain.classes;

namespace LingoPartnerApp
{
  internal class Program
  {
    static void Main(string[] args)
    {
      DotEnv.Load();
      if (System.Environment.GetEnvironmentVariable("ENV") == "development")
      {
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.Listeners.Add(new TextWriterTraceListener("./log.txt"));
      }

      // Example usage
      Trace.TraceInformation("Application started");
      Console.WriteLine("Welcome to LingoPartner!");

      // Create new administration
      Administration schoolAdministration = new();
      Menu menu = new Menu(schoolAdministration);
      menu.Show();

    }
  }
}