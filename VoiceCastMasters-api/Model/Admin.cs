namespace VoiceCastMasters_api.Model;

public class Admin : User
{
    public Admin(long id, string name, DateTime birthdate, string email, string password, string phone, string profilePicture) : 
        base(id, name, birthdate, email, password, phone, profilePicture)
    {
    }
}