using VoiceCastMasters_api.Enums;

namespace VoiceCastMasters_api.Model;

public class ActorDTO : User
{
    public long ID { get; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string ProfilePicture { get; set; } = "https://cdn.britannica.com/07/183407-050-C35648B5/Chicken.jpg";
    
    public string Role { get; set; }
    public Dictionary<ActorDTO, byte> Relations { get; set; }
    public List<string> SampleURL { get; set; }

    public ActorDTO(long id, string name, DateTime birthdate, string email, string password, string phone,
        string profilePicture, Dictionary<ActorDTO, byte> relations, List<string> sampleUrl, Roles role = Roles.Actor) : base(id, name, birthdate, email, password, phone, profilePicture)
    {
        ID = id;
        Name = name;
        BirthDate = birthdate;
        Email = email;
        Password = password;
        Phone = phone;
        ProfilePicture = profilePicture;
        Relations = relations;
        SampleURL = sampleUrl;
        Role = role.ToString();
    }

    public ActorDTO(Actor actor) : base(actor)
    {
        ID = actor.ID;
        Name = actor.Name;
        BirthDate = actor.BirthDate;
        Email = actor.Email;
        Password = actor.Password;
        Phone = actor.Phone;
        ProfilePicture = actor.ProfilePicture;
        Relations = actor.Relations.ToDictionary(kvp => new ActorDTO(kvp.Key), kvp => kvp.Value);
        SampleURL = actor.SampleURL;
        Role = actor.Role.ToString();
    }
}