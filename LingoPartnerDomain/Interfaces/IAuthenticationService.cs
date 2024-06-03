using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces
{
  public interface IAuthenticationService
  {
    bool Authenticate(string username, string password);
    User GetCurrentUser();
  }
}