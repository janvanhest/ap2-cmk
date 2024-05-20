using LingoPartnerDomain.classes;
namespace LingoPartnerDomain.interfaces
{
  public interface IUserRepository
  {
    User? AddUser(User user);
    List<User> GetUsers();
  }
}