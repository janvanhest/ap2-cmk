using System.Net.Mail;
using LingoPartnerDomain;
using LingoPartnerDomain.classes;

namespace LingoPartnerConsole.Classes;

public static class ConsoleHelper
{
  public static string GetStringInput(string promptMessage)
  {
    string? input = null;
    do
    {
      Console.WriteLine(promptMessage);
      input = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(input))
      {
        Console.WriteLine("Invalid input. Please try again.");
      }
    } while (string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input));
    return input;
  }
  public static DateTime GetDateInput(string promptMessage = "Enter a date in the format (YYYY/MM/DD):")
  {
    DateTime date;
    bool isValidDate;
    do
    {
      Console.WriteLine(promptMessage);
      isValidDate = DateTime.TryParse(Console.ReadLine(), out date); // Try to parse the input to a DateTime
    } while (!isValidDate);
    return date;
  }
  public static MailAddress GetEmailInput(string promptMessage = "Enter an email address:")
  {
    MailAddress? email = null;
    do // Keep asking for input until a valid email is entered
    {
      Console.WriteLine(promptMessage);
      string input = Console.ReadLine() ?? string.Empty; // Avoid null input

      if (!string.IsNullOrWhiteSpace(input))
      {
        try
        {
          email = new MailAddress(input);
          break; // Valid email, break out of the loop
        }
        catch (FormatException)
        {
          Console.WriteLine("Invalid email address. Please try again.");
        }
      }
      else
      {
        Console.WriteLine("Email cannot be empty. Please try again.");
      }

    } while (true);

    return email;
  }
  public static string GetPasswordInput(string promptMessage = "Enter a password:")
  {
    string password;
    do
    {
      Console.WriteLine(promptMessage);
      password = Console.ReadLine() ?? string.Empty;

      if (!IsValidPassword(password))
      {
        Console.WriteLine("Invalid password. Please ensure your password meets the required criteria. (Min 8 characters, uppercase, lowercase, number, special character)");
      }
    } while (!IsValidPassword(password));

    return password;
  }

  private static bool IsValidPassword(string password)
  {
    // Password length requirement
    const int MinPasswordLength = 8;

    // You can add more complex checks here if needed
    bool hasMinLength = password.Length >= MinPasswordLength;
    bool hasUpperCase = password.Any(char.IsUpper);
    bool hasLowerCase = password.Any(char.IsLower);
    bool hasNumbers = password.Any(char.IsDigit);
    bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));
    return hasMinLength && hasUpperCase && hasLowerCase && hasNumbers && hasSpecialChar;

    // FIXME: This is simple password validation logic, maybe use a regex? 
    // Regular expression to check if password is at least 8 characters long,
    // contains an uppercase letter, a lowercase letter, a number, and a special character
    // var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$");
    // return regex.IsMatch(password);
  }
  public static void PrintTeacher(User user)
  {
    Console.WriteLine("\n====================================");
    Console.WriteLine($"Username: {user.UserName}");
    Console.WriteLine("====================================\n");
  }
}
