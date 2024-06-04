using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces.Services
{
  public interface IAuthenticationService
  {
    bool Authenticate(string username, string password);
    User GetCurrentUser();
  }
}