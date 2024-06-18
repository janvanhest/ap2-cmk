using System.Net.Mail;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.Classes;
using LingoPartnerConsole.Helpers;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerConsole.Views
{
  public class UserAdd
  {
    private IUserService userService;

    public UserAdd(IUserService userService)
    {
      this.userService = userService;
    }

    public void Show()
    {
      ConsoleHelper.DisplayMessage("Add a new user");
      string firstName = ConsoleHelper.GetStringInput("Enter first name:");
      string middleName = ConsoleHelper.GetStringInput("Enter middle name: (- for none)");
      string lastName = ConsoleHelper.GetStringInput("Enter last name:");
      DateTime dateOfBirth = ConsoleHelper.GetDateInput("Enter date of birth (YYYY-MM-DD):");
      MailAddress email = ConsoleHelper.GetEmailInput("Enter email address:");
      string password = ConsoleHelper.GetPasswordInput("Enter password:");
      string username = ConsoleHelper.GetStringInput("Enter username:");
      UserRole role = ConsoleHelper.GetUserRole("Enter role (Admin, Teacher, Student):");

      // Create the user object
      User newUser = new(
          id: null,
          firstName: firstName,
          middleName: middleName == "-" ? string.Empty : middleName,
          lastName: lastName,
          dateOfBirth: dateOfBirth,
          email: email,
          password: password,
          username: username,
          role: role
      );

      // Add the user to the administration
      userService.RegisterUser(newUser, password);
      Console.WriteLine($"User {firstName} {lastName} successfully added as {role}.");
    }
  }
}
