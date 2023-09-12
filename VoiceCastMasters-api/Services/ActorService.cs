using Microsoft.AspNetCore.Identity;
using VoiceCastMasters_api.Auth;
using VoiceCastMasters_api.DAL;
using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Services;

public class ActorService : IActorService
{
    private IRepository<Actor> _repository;
    private IAuthorization _authorization;
    public ActorService(IRepository<Actor> repository, IAuthorization authorization)
    {
        _repository = repository;
        _authorization = authorization;
    }
    public async Task<List<Actor>?> GetActorsList()
    {
        IEnumerable<Actor>? actors = await _repository.GetAll();
        return actors.ToList();
    }
    
    public async Task<Actor?> GetActorByID(long id)
    {
        return await _repository.GetById(id);
    }

    public async Task<bool> UpdateUser(long id, Actor actor)
    {
        Actor? actorFromDb = await GetActorByID(actor.ID);
        if (actorFromDb == null) return false;
        PasswordVerificationResult passwordChanged = _authorization.Authorize(actorFromDb.Name, actorFromDb.Password, actor.Password);
        if (actorFromDb.Name != actor.Name || passwordChanged != PasswordVerificationResult.Success)
        {
            actor.Password = _authorization.HashPassword(actor.Name, actor.Password);
        }
        return await _repository.Update(id, actor);
    }

    public async Task<bool> DeleteUser(long id)
    {
        return await _repository.Delete(id);
    }

    public async Task<bool> AddActor(ActorDTO actorDto)
    {
        actorDto.SampleURL = new List<string>();
        Actor actor;
        DateTime birthDate = DateTime.MinValue;
        DateTime.TryParse(actorDto.BirthDate, out birthDate);

        if (actorDto.Role == "Director")
        {
            actor = new Director(actorDto.Name, birthDate,
                actorDto.Email, actorDto.Password, actorDto.Phone,actorDto.SampleURL,
                actorDto.ProfilePicture
                );
        }
        else
        {
            actor = new Actor(actorDto.Name, birthDate, actorDto.Email, actorDto.Password, actorDto.Phone,
                actorDto.SampleURL, actorDto.ProfilePicture
                );
        }
        return await _repository.Add(actor);
    }

    public async Task<Actor?> GetActorByEmail(string email)
    {
        return await _repository.GetByEmail(email);
    }
}

    