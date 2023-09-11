using Microsoft.AspNetCore.Identity;
using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.Auth;

public interface IAuthorization
{
    public PasswordVerificationResult Authorize(string username, string hashedPassword, string providedPass);
    public string HashPassword(string username, string passwordToHash);
}