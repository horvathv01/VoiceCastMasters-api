using VoiceCastMasters_api.DAL;
using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Services;

public class UserService : IUserService
{
    private readonly IActorService _actorService;
    private readonly IRepository<User> _userRepository;

    public UserService(IActorService actorService, IRepository<User> userRepository)
    {
        _actorService = actorService;
        _userRepository = userRepository;
    }
    
    public List<User> GetAllUsers()
    {
        return _actorService.GetActorsList().Cast<User>().ToList();
    }

    public User GetUserById(long id)
    {
        return _userRepository.GetById(id);
    }

    public bool AddUser(User user)
    {
        if (_userRepository.Add(user))
        {
            return true;
        }
        return false;
    }

    public async Task<bool> UpdateUser(User user)
    {
       return _actorService.UpdateUser(user.ID, user);
    }

    public async Task<bool> DeleteUser(User user)
    {
       return _actorService.DeleteUser(user.ID);
    }

    public User? GetUserByEmail(string email)
    {
        var user = _actorService.GetActorsList().First(actor => actor.Email.Equals(email));
        return user;
    }
}