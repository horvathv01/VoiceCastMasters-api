using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Services;

public interface IActorService
{
    public Task<List<Actor>?> GetActorsList();
    public Task<Actor?> GetActorByID(long id);
    public Task<bool> UpdateUser(long id, Actor actor);
    public Task<bool> DeleteUser(long id);
    public Task<bool> AddActor(ActorDTO actor);

    Task<Actor?> GetActorByEmail(string email);
}