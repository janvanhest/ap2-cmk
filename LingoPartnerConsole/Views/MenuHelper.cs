using LingoPartnerDomain;

namespace LingoPartnerConsole.Views
{
  internal class MenuHelper
  {
    public static void ReturnToMenu(Administration schoolAdministration)
    {
      Console.WriteLine("Press any key to return to menu...");
      Console.ReadKey();
      Menu menu = new Menu(schoolAdministration);
      menu.Show();
    }
  }
}