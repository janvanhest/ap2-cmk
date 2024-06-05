using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerInfrastructure.Services
{
  public class AuthenticationService : IAuthenticationService
  {
    private readonly IUserRepository userRepository;
    private User? currentUser;

    public AuthenticationService(IUserRepository userRepository)
    {
      this.userRepository = userRepository;
    }

    public bool Authenticate(string username, string password)
    {
      var user = this.userRepository.GetUserByUsername(username);
      if (user != null && user.VerifyPassword(password))
      {
        this.currentUser = user;
        return true;
      }
      return false;
    }

    public User? CurrentUser => currentUser;
  }
}
