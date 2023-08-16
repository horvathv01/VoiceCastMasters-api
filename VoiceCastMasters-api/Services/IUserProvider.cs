using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Services;

public interface IUserProvider
{
    public List<Actor> GetActorsList();
    public User GetUserByID(int id);
    public bool RegisterUser(User user);
    public bool AddActor(User user);
}