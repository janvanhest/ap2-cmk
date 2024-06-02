using LingoPartnerConsole.Helpers;
using LingoPartnerDomain.Classes;

namespace LingoPartnerConsole.Views
{
  internal class MenuHelper
  {
    public static void ReturnToMenu(Administration schoolAdministration)
    {
      ConsoleHelper.DisplayTypingAnimation("Press any key to return to the menu...");
      Console.ReadKey();
      Menu menu = new Menu(schoolAdministration);
      menu.Show();
    }
  }
}