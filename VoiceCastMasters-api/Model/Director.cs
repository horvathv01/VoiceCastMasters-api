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
        string? profilePicture = null, 
        //Dictionary<Actor, byte>? relations = null, 
        List<string>? sampleUrl = null
        ) : base(
        name, 
        birthDate, 
        email, 
        password, 
        phone, 
        profilePicture
        //relations, 
        //sampleUrl
        )
    {
        Role = Roles.Director;
    }
}