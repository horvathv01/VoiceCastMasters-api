using VoiceCastMasters_api.Model;
using Microsoft.AspNetCore.Identity;

namespace VoiceCastMasters_api.Auth;

public class Authorization : IAuthorization
{   private PasswordHasher<string> _passwordHasher = new ();
    public PasswordVerificationResult Authorize(User user, string hashedPassword, string providedPass)
    {
        string salt = GenerateSalt(user);
        return _passwordHasher.VerifyHashedPassword(salt, hashedPassword, providedPass);
    }

    public string HashPassword(User user, string passwordToHash)
    {
        string salt = GenerateSalt(user);
        return _passwordHasher.HashPassword(salt, passwordToHash);
    }

    private string GenerateSalt(User user)
    {
        throw new NotImplementedException();
    }
}