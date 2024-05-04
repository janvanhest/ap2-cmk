using System;
using System.Net.Mail;
using LingoPartnerConsole.Classes;
using LingoPartnerDomain.enums;
using LingoPartnerDomain.classes;

namespace LingoPartnerConsole.Views
{
  public class UserAdd
  {
    private Administration SchoolAdministration;

    public UserAdd(Administration administration)
    {
      SchoolAdministration = administration;
    }

    public void Show()
    {
      Console.WriteLine("Add a new user");
      string firstName = ConsoleHelper.GetStringInput("Enter first name:");
      string middleName = ConsoleHelper.GetStringInput("Enter middle name:");
      string lastName = ConsoleHelper.GetStringInput("Enter last name:");
      DateTime dateOfBirth = ConsoleHelper.GetDateInput("Enter date of birth (YYYY-MM-DD):");
      MailAddress email = ConsoleHelper.GetEmailInput("Enter email address:");
      string password = ConsoleHelper.GetPasswordInput("Enter password:");
      string username = ConsoleHelper.GetStringInput("Enter username:");
      UserRole role = ConsoleHelper.GetUserRole("Enter role (Admin, Teacher, Student):");

      // Create the user object
      User newUser = new User(
          firstName: firstName,
          middleName: middleName,
          lastName: lastName,
          dateOfBirth: dateOfBirth,
          email: email,
          password: password,
          username: username,
          role: role
      );

      // Add the user to the administration
      SchoolAdministration.Add(newUser);
      Console.WriteLine($"User {firstName} {lastName} successfully added as {role}.");

    }
  }
}
