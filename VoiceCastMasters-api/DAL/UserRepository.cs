using Microsoft.EntityFrameworkCore;
using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.DAL;

public class UserRepository : IRepository<User>
{
    private DatabaseContext _databaseContext;
    public UserRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public bool Add(User entity)
    {
        try
        {
            _databaseContext.Add(entity);
            _databaseContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public User GetById(long id)
    {
        try
        {
            User entity = _databaseContext.Find<User>(id);
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool Update(long id, User entity)
    {
        try
        {
            _databaseContext.Update(entity);
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
            User entity = _databaseContext.Find<User>(id);
            _databaseContext.Remove(entity);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public IEnumerable<User> GetAll()
    {
        return _databaseContext.Actors.ToList();
    }

    public User? GetByEmail(string email)
    {
        return _databaseContext.Actors.FirstOrDefault(e => e.Email.Equals(email));
    }
}