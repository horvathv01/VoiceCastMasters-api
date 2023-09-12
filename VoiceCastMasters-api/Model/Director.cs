using VoiceCastMasters_api.Enums;

namespace VoiceCastMasters_api.Model;

public class Director : Actor
{
    public Director(
        string name, 
        DateTime birthDate, 
        string email, 
        string password, 
        string phone,
        List<string> sampleUrl,
        string? profilePicture = null 
        //Dictionary<Actor, byte>? relations = null, 
        
        ) : base(
        name, 
        birthDate, 
        email, 
        password, 
        phone, 
        sampleUrl,
        profilePicture
        //relations, 
        
        )
    {
        Role = Roles.Director;
    }
}