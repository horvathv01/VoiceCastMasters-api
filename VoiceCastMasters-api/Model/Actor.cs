using VoiceCastMasters_api.Enums;

namespace VoiceCastMasters_api.Model;

public class Actor : User
{
//    public Dictionary<Actor, byte> Relations { get; set; }
    public List<string> SampleURL { get; set; }

    public Actor(
        string name, 
        DateTime birthDate, 
        string email, 
        string password, 
        string phone, 
        
        //Dictionary<Actor, byte>? relations = null, 
        List<string> sampleURL,
        string? profilePicture = null
        ) :
        base(name, birthDate, email, password, phone, profilePicture)
    {
        Role = Roles.Actor;
        //Relations = relations ?? new Dictionary<Actor, byte>();
        SampleURL = sampleURL;
    }
}