using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Services;

public interface IActorService
{
    public List<Actor> GetActorsList();
    public User GetUserById(long id);
    public bool UpdateUser(long id, User newUser);
    public bool DeleteUser(long id);
    public bool RegisterUser(User user);
}