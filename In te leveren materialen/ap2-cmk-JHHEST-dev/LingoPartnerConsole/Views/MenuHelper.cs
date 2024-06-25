using LingoPartnerConsole.Helpers;
using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerConsole.Views
{
  internal class MenuHelper
  {
    public static void ReturnToMenu(
        ILearningStreakService learningStreakService,
        ILearningModuleService learningModuleService,
        IAuthenticationService authenticationService,
        IUserService userService,
        ILearningActivityService learningActivityService,
        IProgressService progressService
      )
    {
      ConsoleHelper.DisplayTypingAnimation("Press any key to return to the menu...");
      Console.ReadKey();
      Menu menu = new(
        learningStreakService,
        learningModuleService,
        authenticationService,
        userService,
        learningActivityService,
        progressService
        );
      menu.Show();
    }
  }
}