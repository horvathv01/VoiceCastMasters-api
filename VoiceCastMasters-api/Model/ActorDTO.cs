using System.Text.Json.Serialization;
using VoiceCastMasters_api.Enums;

namespace VoiceCastMasters_api.Model;

public class ActorDTO
{
    public long ID { get; }
    public string Name { get; set; }
    public string BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string ProfilePicture { get; set; } = "https://cdn.britannica.com/07/183407-050-C35648B5/Chicken.jpg";
    
    public string Role { get; set; }
    //public Dictionary<ActorDTO, byte> Relations { get; set; }
    public List<string> SampleURL { get; set; }
    

    [Newtonsoft.Json.JsonConstructor]
    public ActorDTO(
        long id, 
        string name, 
        string birthDate, 
        string email, 
        string password, 
        string phone,
        string profilePicture, 
        //Dictionary<ActorDTO, byte> relations, 
        List<string> sampleUrl, 
        string role = "Actor"
        ) 
    {
        ID = id;
        Name = name;
        //BirthDate = DateTime.Parse(birthdate);
        BirthDate = birthDate;
        Email = email;
        Password = password;
        Phone = phone;
        ProfilePicture = profilePicture;
        //Relations = relations;
        SampleURL = sampleUrl;
        Role = role;
    }

    public ActorDTO(Actor actor)
    {
        ID = actor.ID;
        Name = actor.Name;
        BirthDate = actor.BirthDate.ToString();
        Email = actor.Email;
        Password = actor.Password;
        Phone = actor.Phone;
        ProfilePicture = actor.ProfilePicture;
        //Relations = actor.Relations.ToDictionary(kvp => new ActorDTO(kvp.Key), kvp => kvp.Value);
        SampleURL = actor.SampleURL;
        Role = actor.Role.ToString();
    }

    public ActorDTO(User user)
    {
        try
        {
            Actor actor = (Actor)user;
            ID = actor.ID;
            Name = actor.Name;
            BirthDate = actor.BirthDate.ToString();
            Email = actor.Email;
            Password = actor.Password;
            Phone = actor.Phone;
            ProfilePicture = actor.ProfilePicture;
            //Relations = actor.Relations.ToDictionary(kvp => new ActorDTO(kvp.Key), kvp => kvp.Value);
            SampleURL = actor.SampleURL;
            Role = actor.Role.ToString();
        }
        catch (Exception e)
        {
            Console.WriteLine($"ActorDTO could not be made out of user {user.Name} (id: {user.ID}).");
            Console.WriteLine(e);
            throw;
        }

    }

    
    
    public override string ToString()
    {
        return $"{ID}, {Name}, {BirthDate}, {Email}, {Password}, {Phone}, {ProfilePicture}, {Role}";
    }
}