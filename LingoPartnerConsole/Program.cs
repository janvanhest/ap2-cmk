// See https://aka.ms/new-console-template for more information
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
      Console.WriteLine("Welcome to LingoPartner!");
      // Create new administration
      Administration schoolAdministration = new();
      Menu menu = new Menu(schoolAdministration);
      menu.Show();

    }
  }
}