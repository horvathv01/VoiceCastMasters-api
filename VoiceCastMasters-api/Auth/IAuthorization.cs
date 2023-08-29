using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Auth;

public interface IAuthorization
{
    public bool Authorize();
    public string HashPassword(User user, string passwordToHash);
}