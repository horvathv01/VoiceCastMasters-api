namespace VoiceCastMasters_api.Model;

public class Actor : User
{
    public Dictionary<Actor, byte> Relations { get; set; }
    public List<string> SampleURL { get; set; }
    public bool IsDirector { get; set; } = false;

    public Actor(Guid id, string name, DateTime birthdate, string email, string password, string phone, string profilePicture) : 
        base(id, name, birthdate, email, password, phone, profilePicture)
    {
        
    }
}