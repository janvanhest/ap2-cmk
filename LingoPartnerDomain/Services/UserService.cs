using LingoPartnerDomain.Classes;
using LingoPartnerDomain.Interfaces.Repositories;
using LingoPartnerDomain.Interfaces.Services;

namespace LingoPartnerDomain.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public User? RegisterUser(User user, string password)
    {
      return _userRepository.Add(user, password);
    }

    public IEnumerable<User> GetAllUsers()
    {
      return _userRepository.GetAll();
    }

    public User? UpdateUser(User user, string? password)
    {
      return _userRepository.Update(user, password);
    }

    public User? GetUserByUsername(string username)
    {
      return _userRepository.GetBy(username);
    }
  }
}