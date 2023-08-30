using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Services;

public interface IActorService
{
    public List<Actor> GetActorsList();
    public Actor GetActorByID(long id);
    public bool UpdateUser(long id, Actor actor);
    public bool DeleteUser(long id);
    public bool AddActor(ActorDTO actor);
}