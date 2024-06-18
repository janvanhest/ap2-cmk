
using LingoPartnerDomain.Classes;

namespace LingoPartnerDomain.Interfaces.Services
{
  public interface IUserService
  {
    User? RegisterUser(User user, string password);
    IEnumerable<User> GetAllUsers();
    User? UpdateUser(User user, string? password);
    User? GetUserByUsername(string username);
  }
}