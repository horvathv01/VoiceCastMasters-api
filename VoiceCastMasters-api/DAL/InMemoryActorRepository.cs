using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.DAL;

public class InMemoryActorRepository : IRepository<Actor>
{
    private List<Actor> _actors;

    public InMemoryActorRepository(List<Actor>? actors = null)
    {
        if (actors == null)
        {
            Prepopulate();
        }
        else
        {
            _actors = actors;
        }
    }

    private void Prepopulate()
    {
        _actors = new List<Actor>();
        Random random = new Random();
        for (int i = 0; i < 15; i++)
        {
            int year = random.Next(1950, 2015);
            int month = random.Next(1, 13);
            int day = random.Next(1,29);
            Actor actor = new Actor($"actor{i}", new DateTime(year, month, day).ToString(), 
                $"actor{i}@actorsguild.com", $"password{i}", $"+3670/123-456{i}");
            _actors.Add(actor);
        }

        Console.WriteLine("InMemory Actor repository has been prepopulated.");
    }
    
    public bool Add(Actor entity)
    {
        try
        {
            _actors.Add(entity);
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
        return _actors.First(a => a.ID == id);
    }

    public bool Update(long id, Actor entity)
    {
        try
        {
            Actor actor = _actors.First(a => a.ID == id);
            foreach (var property in typeof(Actor).GetProperties())
            {
                if (property.Name != "ID")
                {
                    var newValue = property.GetValue(entity);
                    property.SetValue(actor, newValue);
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

    public bool Delete(long id)
    {
        try
        {
            Actor actor = _actors.First(a => a.ID == id);
            _actors.Remove(actor);
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
        return _actors;
    }
}