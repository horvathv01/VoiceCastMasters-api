using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoiceCastMasters_api.Model;

public abstract class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ID { get; }
    
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Phone { get; set; }
    public string ProfilePicture { get; set; }

    public User(long id, string name, DateTime birthdate, string email, string password, string phone,
        string? profilePicture = null)
    {
        ID = id;
        Name = name;
        BirthDate = birthdate;
        Email = email;
        Password = password;
        Phone = phone;
        ProfilePicture = profilePicture ?? "https://cdn.britannica.com/07/183407-050-C35648B5/Chicken.jpg";
    }
}