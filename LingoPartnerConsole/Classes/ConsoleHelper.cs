using System.Net.Mail;
using LingoPartnerDomain.classes;
using LingoPartnerDomain.enums;

namespace LingoPartnerConsole.helpers
{

  public static class ConsoleHelper
  {
    private static readonly ConsoleColor[] RainbowColors = new[]
    {
    ConsoleColor.Red,
    ConsoleColor.DarkYellow, // Using DarkYellow as a substitute for Orange
    ConsoleColor.Yellow,
    ConsoleColor.Green,
    ConsoleColor.Blue,
    ConsoleColor.Magenta // Using Magenta as a substitute for Violet
  };
    private static readonly ConsoleColor[] AllColors =
      Enum
        .GetValues(typeof(ConsoleColor))
        .Cast<ConsoleColor>()
        .ToArray();
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

    public static UserRole GetUserRole(
      string promptMessage = "Enter a role (Admin, Teacher, Student):")
    {
      UserRole role;
      bool isValidRole;
      do
      {
        Console.WriteLine(promptMessage);
        string input = Console.ReadLine() ?? string.Empty;
        isValidRole = Enum.TryParse(input, true, out role); // Try to parse the input to a UserRole
        if (!isValidRole)
        {
          Console.WriteLine("Invalid role. Please try again.");
        }
      } while (!isValidRole);
      return role;
    }
    public static void PrintUser(User user)
    {
      Console.WriteLine("\n====================================");
      Console.WriteLine($"Username: {user.FirstName} {user.MiddleName} {user.LastName}");
      Console.WriteLine($"Email: {user.Email}");
      Console.WriteLine($"Role: {user.Role}");
      Console.WriteLine("====================================\n");
    }
    public static void DisplayTypingAnimation(string message, bool useRainbowColors = false)
    {
      ConsoleColor originalColor = Console.ForegroundColor;
      Random random = new Random();

      for (int i = 0; i < message.Length; i++)
      {
        if (useRainbowColors)
        {
          Console.ForegroundColor = RainbowColors[i % RainbowColors.Length];
        }

        Console.Write(message[i]);
        // Thread.Sleep(random.Next(25, 101)); // Typing effect delay with random intervals
        Thread.Sleep(random.Next(6, 25)); // Typing effect delay with random intervals

        // Blinking cursor effect
        if (i < message.Length - 1)
        {
          ToggleCursorVisibility(false);
          Thread.Sleep(random.Next(6, 25));
          ToggleCursorVisibility(true);
        }
      }

      Console.WriteLine();
      Console.ForegroundColor = originalColor; // Reset to the original color
    }

    private static void ToggleCursorVisibility(bool visible)
    {
      Console.CursorVisible = visible;
    }


    public static void DisplayMessage(string message, MessageType messageType = MessageType.INFORMATION)
    {
      string line = new string('-', message.Length);
      ConsoleColor originalColor = Console.ForegroundColor;

      switch (messageType)
      {
        case MessageType.INFORMATION:
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          break;
        case MessageType.WARNING:
          Console.ForegroundColor = ConsoleColor.Red;
          break;
        case MessageType.CONFORMATION:
          Console.ForegroundColor = ConsoleColor.Blue;
          break;
        case MessageType.ERROR:
          Console.ForegroundColor = ConsoleColor.Yellow;
          break;
        case MessageType.SUCCES:
          Console.ForegroundColor = ConsoleColor.Green;
          break;
      }
      Console.WriteLine(line);
      ConsoleHelper.DisplayTypingAnimation(message);
      Console.WriteLine(line);

      // Reset to the original color
      Console.ForegroundColor = originalColor;
    }

    public static LearningActivityType GetLearningActivityType()
    {
      LearningActivityType learningActivityType;
      bool isValidLearningActivityType;
      do
      {
        ConsoleHelper.DisplayTypingAnimation("Enter the corresponding number for the LearningActivityType:");
        for (int i = 0; i < Enum.GetValues(typeof(LearningActivityType)).Length; i++)
        {
          Console.WriteLine($"{i + 1}. {Enum.GetValues(typeof(LearningActivityType)).GetValue(i)}");
        }
        string input = Console.ReadLine() ?? string.Empty;
        isValidLearningActivityType = Enum.TryParse(input, true, out learningActivityType); // Try to parse the input to a LearningActivityType
        if (!isValidLearningActivityType)
        {
          Console.WriteLine("Invalid LearningActivityType. Please try again.");
        }
      } while (!isValidLearningActivityType);
      return learningActivityType;
    }

    public static int GetIntInput(string v)
    {
      int number;
      bool isValidNumber;
      do
      {
        Console.WriteLine(v);
        isValidNumber = int.TryParse(Console.ReadLine(), out number); // Try to parse the input to an int
        if (!isValidNumber)
        {
          Console.WriteLine("Invalid number. Please try again.");
        }
      } while (!isValidNumber);
      return number;
    }
  }
}