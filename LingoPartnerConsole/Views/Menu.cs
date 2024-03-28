using System;
using LingoPartnerDomain;
using LingoPartnerDomain.classes;

namespace LingoPartnerConsole.Views
{
  internal class Menu
  {
    public Administration SchoolAdministration;
    public Menu(Administration schoolAdministration)
    {
      SchoolAdministration = schoolAdministration;
    }
    public void Show()
    {
      // Two carriage returns
      Console.WriteLine("\n\n");
      Console.WriteLine("Welcome to the LingoPartner Console Application");
      Console.WriteLine("1. Add a teacher");

      // Console.WriteLine("2. Add a student");
      // Console.WriteLine("3. Add a course");
      // Console.WriteLine("4. Add a student to a course");
      // Console.WriteLine("5. Add a teacher to a course");
      // Console.WriteLine("6. Show all teachers");
      // Console.WriteLine("7. Show all students");
      // Console.WriteLine("8. Show all courses");
      // Console.WriteLine("9. Show all students in a course");
      // Console.WriteLine("10. Show all teachers in a course");
      // Console.WriteLine("11. Exit");
      Console.WriteLine("Please enter your choice:");
      string choice = Console.ReadLine();
      switch (choice)
      {
        case "1":
          TeacherAdd addTeacher = new TeacherAdd(SchoolAdministration);
          addTeacher.Show();
          break;
        case "11":
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("Invalid choice");
          break;
      }
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
      Console.Clear();
      Show();
    }
  }
}

