using LingoPartnerDomain.classes;

namespace LingoPartnerConsole.Views
{
  internal class MenuHelper
  {
    public static void ReturnToMenu(Administration schoolAdministration)
    {
      Console.WriteLine("\nPress any key to return to menu...\n");
      Console.ReadKey();
      Menu menu = new Menu(schoolAdministration);
      menu.Show();
    }
  }
}