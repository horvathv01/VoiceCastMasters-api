using Microsoft.EntityFrameworkCore;
using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.DAL;

public class UserRepository : IRepository<User>
{
    private DbContext _databaseContext;
    public UserRepository(DbContext databaseContext)
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
        throw new NotImplementedException();
    }

    public bool Update(long id, User entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(long id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public User? GetByEmail(string email)
    {
        throw new NotImplementedException();
    }
}