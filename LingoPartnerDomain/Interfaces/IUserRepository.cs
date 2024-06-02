using LingoPartnerDomain.Classes;
namespace LingoPartnerDomain.Interfaces
{
  public interface IUserRepository
  {
    User? AddUser(User user);
    IEnumerable<User> GetUsers();
    User? UpdateUser(User user);
    User? GetUserByUsername(string username);
  }
}