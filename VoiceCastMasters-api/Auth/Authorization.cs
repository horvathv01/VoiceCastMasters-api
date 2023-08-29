using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Auth;

public class Authorization : IAuthorization
{
    public bool Authorize()
    {
        throw new NotImplementedException();
    }

    public string HashPassword(User user, string passwordToHash)
    {
        throw new NotImplementedException();
    }
}