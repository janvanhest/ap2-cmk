using LingoPartnerDomain;
using LingoPartnerDomain.classes;
using System.Net.Mail;
using LingoPartnerConsole.Classes;


namespace LingoPartnerConsole.Views
{
  internal class TeacherAdd
  {
    private Administration SchoolAdministration;

    public TeacherAdd(Administration schoolAdministration)
    {
      SchoolAdministration = schoolAdministration;
    }
    public void Show()
    {

      Console.WriteLine("Add a teacher");
      // Guid id,
      Guid id = Guid.NewGuid();
      string firstName = ConsoleHelper.GetStringInput("Enter first name:");
      string middleName = ConsoleHelper.GetStringInput("Enter middle name:");
      string lastName = ConsoleHelper.GetStringInput("Enter last name:");
      DateTime dateOfBirth = ConsoleHelper.GetDateInput();
      MailAddress email = ConsoleHelper.GetEmailInput();
      string password = ConsoleHelper.GetPasswordInput();
      string username = ConsoleHelper.GetStringInput("Enter username:");
      string department = ConsoleHelper.GetStringInput("Enter department:");
      // Teacher teacher = new Teacher(
      //     id,
      //     firstName,
      //     middleName,
      //     lastName,
      //     dateOfBirth,
      //     email,
      //     password,
      //     username,
      //     department
      // );
      // SchoolAdministration.AddTeacher(teacher);
    }
  }
}

