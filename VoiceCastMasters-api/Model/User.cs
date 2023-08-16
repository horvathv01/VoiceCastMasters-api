using System.ComponentModel.DataAnnotations.Schema;

namespace VoiceCastMasters_api.Model;

public abstract class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; }

    public string Name { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string ProfilePicture { get; set; }
    
}