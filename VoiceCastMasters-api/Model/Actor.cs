using VoiceCastMasters_api.Enums;

namespace VoiceCastMasters_api.Model;

public class Actor : User
{
    public Dictionary<Actor, byte> Relations { get; set; }
    public List<string> SampleURL { get; set; }
    public bool IsDirector { get; set; } = false;

    public Actor(long id, string name, DateTime birthdate, string email, string password, string phone, string? profilePicture = null,
        Dictionary<Actor, byte>? relations = null, List<string>? sampleUrl = null, bool? isDirector = null) :
        base(id, name, birthdate, email, password, phone, profilePicture)
    {
        Role = Roles.Actor;
        Relations = relations ?? new Dictionary<Actor, byte>();
        SampleURL = sampleUrl ?? new List<string>();
        IsDirector = isDirector ?? false;
    }
}