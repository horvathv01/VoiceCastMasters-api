using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Services;

public interface IUserService
{
    Task<List<User>> GetAllUsers();
    Task<User> GetUserById(long id);
    Task<bool> AddUser(User user);
    Task<bool> UpdateUser(User user);
    Task<bool> DeleteUser(User user);

    Task<User?> GetUserByEmail(string email);
}