using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Services;

public class UserService : IUserService
{
    private readonly IActorService _actorService;

    public UserService(IActorService actorService)
    {
        _actorService = actorService;
    }
    
    public async Task<List<User>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserById(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddUser(User user)
    {
        throw new NotImplementedException();
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