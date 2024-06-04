using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerDomain.enums;

namespace LingoPartnerConsole.Helpers
{
  public static class AuthenticationHelper
  {
    public static void Authenticate(IAuthenticationService authenticationService)
    {
      while (authenticationService.GetCurrentUser() == null)
      {
        string username = ConsoleHelper.GetStringInput("Enter username: ");
        string password = ReadPassword();

        if (authenticationService.Authenticate(username, password))
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
