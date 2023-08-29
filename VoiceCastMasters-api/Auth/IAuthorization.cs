using Microsoft.AspNetCore.Identity;
using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Auth;

public interface IAuthorization
{
    public PasswordVerificationResult Authorize(User user, string hashedPassword, string providedPass);
    public string HashPassword(User user, string passwordToHash);
}