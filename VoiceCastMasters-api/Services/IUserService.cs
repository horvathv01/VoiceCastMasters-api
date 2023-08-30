using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Services;

public interface IUserService
{
    List<User> GetAllUsers();
    User GetUserById(long id);
    bool AddUser(User user);
    Task<bool> UpdateUser(User user);
    Task<bool> DeleteUser(User user);

    Task<User?> GetUserByEmail(string email);
}