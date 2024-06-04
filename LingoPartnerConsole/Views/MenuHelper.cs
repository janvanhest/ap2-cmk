using LingoPartnerConsole.Helpers;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerConsole.Views
{
  internal class MenuHelper
  {
    public static void ReturnToMenu(
        Administration schoolAdministration,
        ILearningStreakService learningStreakService)
    {

      ConsoleHelper.DisplayTypingAnimation("Press any key to return to the menu...");
      Console.ReadKey();
      Menu menu = new(schoolAdministration, learningStreakService);
      menu.Show();
    }
  }
}