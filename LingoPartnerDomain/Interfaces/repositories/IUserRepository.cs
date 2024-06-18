using LingoPartnerDomain.Classes;
namespace LingoPartnerDomain.Interfaces.Repositories
{
  public interface IUserRepository
  {
    User? Add(User user, string password);
    IEnumerable<User> GetAll();
    User? Update(User user, string? password);
    User? GetBy(string username);
    User? GetById(int id);
  }
}