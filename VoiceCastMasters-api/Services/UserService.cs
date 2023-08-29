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
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUserByEmail(string email)
    {
        return null;
        throw new NotImplementedException();
    }
}