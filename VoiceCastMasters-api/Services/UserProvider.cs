using VoiceCastMasters_api.DAL;
using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Services;

public class UserProvider : IUserProvider
{
    private IRepository<Actor> _repository;
    public UserProvider(IRepository<Actor> repository)
    {
        _repository = repository;
    }
    public List<Actor> GetActorsList()
    {
        return _repository.GetAll().ToList();
    }

    public User GetUserById(long id)
    {
        return _repository.GetById(id);
    }

    public bool UpdateUser(long id, User newUser)
    {
        return _repository.Update(id, (Actor)newUser);
    }

    public bool DeleteUser(long id)
    {
        return _repository.Delete(id);
    }

    public bool RegisterUser(User user)
    {
        return _repository.Add((Actor)user);
    }
}