using System.Net.Mail;
using LingoPartnerConsole.Helpers;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;
using LingoPartnerShared.Helpers;

namespace LingoPartnerConsole.Views
{
  public class UserUpdate
  {
    private readonly IUserService userService;

    public UserUpdate(IUserService userService)
    {
      this.userService = userService;
    }
    public void Show()
    {
      ConsoleHelper.DisplayMessage("Update a user");
      string username = ConsoleHelper.GetStringInput("Enter username:");
      User? user = userService.GetUserByUsername(username);
      if (user == null)
      {
        Console.WriteLine("User not found.");
        return;
      }
      Console.WriteLine("User found:");
      string firstName = AskForUpdate("first name", user.FirstName)
        ? ConsoleHelper.GetStringInput("Enter first name:")
        : user.FirstName;
      string middleName = AskForUpdate("middle name", user.MiddleName)
        ? ConsoleHelper.GetStringInput("Enter middle name:")
        : user.MiddleName;
      string lastName = AskForUpdate("last name", user.LastName)
        ? ConsoleHelper.GetStringInput("Enter last name:")
        : user.LastName;
      DateTime dateOfBirth = AskForUpdate("date of birth", user.DateOfBirth.ToString("yyyy-MM-dd"))
        ? ConsoleHelper.GetDateInput("Enter date of birth (YYYY-MM-DD):")
        : user.DateOfBirth;
      MailAddress email = AskForUpdate("email", user.Email.ToString())
        ? ConsoleHelper.GetEmailInput("Enter email address:")
        : user.Email;
      string password = ConsoleHelper.GetPasswordInput("Enter password:");

      UserRole role = AskForUpdate("role", user.Role.ToString())
        ? ConsoleHelper.GetUserRole("Enter role (Admin, Teacher, Student):")
        : user.Role;

      // Create the user object
      User updatedUser = new(
          id: user.Id,
          firstName: firstName,
          middleName: middleName == "-" ? string.Empty : middleName,
          lastName: lastName,
          dateOfBirth: dateOfBirth,
          email: email,
          password: password,
          username: username,
          role: role
      );

      // Update the user in the repository
      try
      {
        userService.UpdateUser(updatedUser, password);
        Console.WriteLine($"User {username} successfully updated.");
      }
      catch (Exception ex)
      {
        LoggingHelper.LogError(ex, ex.Message);
      }
    }
    // function which ask if a certain field should be updated
    // Function which asks if a certain field should be updated
    private bool AskForUpdate(string fieldName, string currentValue)
    {
      while (true)
      {
        Console.WriteLine($"Do you want to update {fieldName} (Y/N)?");
        Console.WriteLine($"Current value is: {currentValue}");
        string input = Console.ReadLine()?.Trim().ToUpper();
        if (input == "Y")
        {
          return true;
        }
        else if (input == "N")
        {
          return false;
        }
        else
        {
          Console.WriteLine("Invalid input. Please enter 'Y' for Yes or 'N' for No.");
        }
      }
    }
  }
}