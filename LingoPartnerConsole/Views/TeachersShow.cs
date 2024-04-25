using LingoPartnerDomain;
using LingoPartnerDomain.classes;
using System.Net.Mail;
using LingoPartnerConsole.Classes;


namespace LingoPartnerConsole.Views
{
  internal class TeachersShow
  {
    public Administration SchoolAdministration;

    public TeachersShow(Administration schoolAdministration)
    {
      SchoolAdministration = schoolAdministration;
    }

    public void Show()
    {
      //   Console.WriteLine("\n\n");
      //   Console.WriteLine("Teachers:");
      //   foreach (Teacher teacher in SchoolAdministration.Teachers)
      //   {
      //     Console.WriteLine("tada");
      //     Console.WriteLine("teacher id is: " + teacher.Id.ToString());
      //     ConsoleHelper.PrintTeacher(teacher);
      //   }
      //   Console.WriteLine("Press any key to continue...");
      //   Console.ReadKey();
      //   Console.Clear();
      //   MenuHelper.ReturnToMenu(SchoolAdministration);
    }
  }
}