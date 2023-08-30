using VoiceCastMasters_api.Enums;
using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.DAL;

public class InMemoryUserRepository : IRepository<User>
{
    private List<User> _users;
    private readonly IRepository<Actor> _actors;
    
    public InMemoryUserRepository(IRepository<Actor> actors, List<User>? users = null)
    {
        _actors = actors;
        if (users == null)
        {
            Prepopulate();
        }
        else
        {
            _users = users;
        }
    }
    
    private void Prepopulate()
    {
        _users = new List<User>();
        Random random = new Random();
        for (int i = 0; i < 15; i++)
        {
            int year = random.Next(1950, 2015);
            int month = random.Next(1, 13);
            int day = random.Next(1,29);
            User user = new Admin((long)i+1, $"actor{i}", new DateTime(year, month, day).ToString(), 
                $"actor{i}@actorsguild.com", $"password{i}", $"+3670/123-456{i}");
            _users.Add(user);
            
        }

        Console.WriteLine("InMemory User repository has been prepopulated.");
    }
    public bool Add(User entity)
    {
        if (entity.Role == Roles.Admin)
        {
            try
            {
                _users.Add(entity);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }    
        }
        else
        {
            return _actors.Add((Actor)entity);
        }
    }

    public User GetById(long id)
    {
        return _users.First(a => a.ID == id);
    }

    public bool Update(long id, User entity)
    {
        if (entity.Role == Roles.Admin)
        {
            try
            {
                User user = _users.First(a => a.ID == id);
                foreach (var property in typeof(Admin).GetProperties())
                {
                    if (property.Name != "ID")
                    {
                        var newValue = property.GetValue(entity);
                        property.SetValue(user, newValue);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }    
        }
        else
        {
            return _actors.Update(id, (Actor)entity);
        }
    }

    public bool Delete(long id)
    {
        try
        {
            User user = _users.First(a => a.ID == id);
            _users.Remove(user);
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
        List<Actor> allActors = _actors.GetAll().ToList();
        List<User> allUsers = _users;
        foreach (var actor in allActors)
        {
            allUsers.Add(actor);
        }
        return allUsers;
    }
}