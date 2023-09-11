using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using VoiceCastMasters_api.Enums;

namespace VoiceCastMasters_api.Model;

public abstract class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ID { get; }
    
    public string Name { get; set; }
    //public DateTime BirthDate { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string ProfilePicture { get; set; }

    public Roles? Role { get; set; } = null;
    
    [Newtonsoft.Json.JsonConstructor]
    public User(string name, DateTime birthDate, string email, string password, string phone,
        string? profilePicture = null)
    {
//        ID = id;
        Name = name;
        //DateTime result = DateTime.Now;
        //DateTime.TryParse(birthdate.ToCharArray(), out result);
        //BirthDate = result;
        BirthDate = birthDate;
        Email = email;
        Password = password;
        Phone = phone;
        ProfilePicture = profilePicture ?? "https://cdn.britannica.com/07/183407-050-C35648B5/Chicken.jpg";
    }

    public override string ToString()
    {
        return $"{ID}, {Name}, {BirthDate}, {Email}, {Password}, {Phone}, {ProfilePicture}, {Role}";
    }
}