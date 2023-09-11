﻿using VoiceCastMasters_api.DAL;
using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Services;

public class ActorService : IActorService
{
    private IRepository<Actor> _repository;
    public ActorService(IRepository<Actor> repository)
    {
        _repository = repository;
    }
    public List<Actor> GetActorsList()
    {
        return _repository.GetAll().ToList();
    }
    
    public Actor GetActorByID(long id)
    {
        return _repository.GetById(id);
    }

    public bool UpdateUser(long id, Actor actor)
    {
        return _repository.Update(id, actor);
    }

    public bool DeleteUser(long id)
    {
        return _repository.Delete(id);
    }

    public bool AddActor(ActorDTO actorDto)
    {
        /*
        Dictionary<Actor, byte> relations = actorDto.Relations.Select(rel =>
            new KeyValuePair<Actor, byte>(DTOToActor(rel.Key), rel.Value)).ToDictionary(relation =>
            relation.Key, relation => relation.Value);
        */
        Actor actor;
        DateTime birthDate = DateTime.MinValue;
        DateTime.TryParse(actorDto.BirthDate, out birthDate);

        if (actorDto.Role == "Director")
        {
            actor = new Director(actorDto.Name, birthDate,
                actorDto.Email, actorDto.Password, actorDto.Phone, actorDto.ProfilePicture,
                actorDto.SampleURL
            );
        }
        else
        {
            actor = new Actor(actorDto.Name, birthDate, actorDto.Email, actorDto.Password, actorDto.Phone,
                actorDto.ProfilePicture);
            /*actor = new Actor(actorDto.Name, actorDto.BirthDate.ToString(),
                actorDto.Email, actorDto.Password, actorDto.Phone, actorDto.ProfilePicture,
                actorDto.SampleURL);
            */
        }
        return _repository.Add(actor);
    }

    public Actor? GetActorByEmail(string email)
    {
        return _repository.GetByEmail(email);
    }

    private Actor DTOToActor(ActorDTO dto)
    {
        return _repository.GetById(dto.ID);
    }
}

    