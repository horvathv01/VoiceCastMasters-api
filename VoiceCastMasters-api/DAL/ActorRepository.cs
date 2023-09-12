using Microsoft.EntityFrameworkCore;
using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.DAL;

public class ActorRepository : IRepository<Actor>
{
    private DatabaseContext _databaseContext;
    public ActorRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public bool Add(Actor entity)
    {
        try
        {
            _databaseContext.Actors.Add(entity);
            _databaseContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public Actor GetById(long id)
    {
        try
        {
            Actor entity = _databaseContext.Actors.Find(id);
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool Update(long id, Actor entity)
    {
        try
        {
            _databaseContext.Actors.Update(entity);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        
    }

    public bool Delete(long id)
    {
        try
        {
            Actor entity = _databaseContext.Actors.Find(id);
            _databaseContext.Actors.Remove(entity);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public IEnumerable<Actor> GetAll()
    {
        return _databaseContext.Actors.ToList();
    }

    public Actor? GetByEmail(string email)
    {
        return _databaseContext.Actors.FirstOrDefault(e => e.Email.Equals(email));
    }
}