using VoiceCastMasters_api.Enums;

namespace VoiceCastMasters_api.Model;

public class Director : Actor
{
    public Director(long id, string name, string birthdate, string email, string password, string phone, string? profilePicture = null, Dictionary<Actor, byte>? relations = null, List<string>? sampleUrl = null, bool? isDirector = null) : base(id, name, birthdate, email, password, phone, profilePicture, relations, sampleUrl, isDirector)
    {
        Role = Roles.Director;
    }
}