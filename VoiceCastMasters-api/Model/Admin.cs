using VoiceCastMasters_api.Enums;

namespace VoiceCastMasters_api.Model;

public class Admin : User
{
    public Admin(long id, string name, string birthdate, string email, string password, string phone, string profilePicture = "") : 
        base(name, birthdate, email, password, phone, profilePicture)
    {
        Role = Roles.Admin;
    }
}