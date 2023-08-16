using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoiceCastMasters_api.Model;

public abstract class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; }
    
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required] 
    public string ProfilePicture { get; set; } = "https://cdn.britannica.com/07/183407-050-C35648B5/Chicken.jpg";
}