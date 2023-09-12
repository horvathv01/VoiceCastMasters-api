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
    public async Task<bool> Add(Actor entity)
    {
        try
        {
            await _databaseContext.Actors.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<Actor?> GetById(long id)
    {
        return await _databaseContext.Actors.FindAsync(id);
    }

    public async Task<IEnumerable<Actor>?> GetListByIds(List<long> ids)
    {
        return _databaseContext.Actors.Where(t => ids.Contains(t.ID));
    }

    public async Task<bool> Update(long id, Actor entity)
    {
        try
        {
            _databaseContext.Actors.Update(entity);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        
    }

    public async Task<bool> Delete(long id)
    {
        try
        {
            Actor? entity = await _databaseContext.Actors.FindAsync(id);
            _databaseContext.Actors.Remove(entity);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<IEnumerable<Actor>> GetAll()
    {
        return await _databaseContext.Actors.ToListAsync();
    }

    public async Task<Actor?> GetByEmail(string email)
    {
        return await _databaseContext.Actors.FirstOrDefaultAsync(e => e.Email.Equals(email));
    }
}