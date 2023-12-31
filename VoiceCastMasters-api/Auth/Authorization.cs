﻿using VoiceCastMasters_api.Model;
using Microsoft.AspNetCore.Identity;

namespace VoiceCastMasters_api.Auth;

public class Authorization : IAuthorization
{   private PasswordHasher<string> _passwordHasher = new ();
    private List<char> _abc = new()
    {
        'a', 'á', 'b', 'c', 'd', 'e', 'é', 'f', 'g', 'h',
        'i', 'í', 'j', 'k', 'l', 'm', 'n', 'o', 'ó', 'ö', 'ő', 'p', 'q', 
        'r', 's', 't', 'u', 'ú', 'ü', 'ű', 'v', 'w', 'x', 'y', 'z'
    };
    public PasswordVerificationResult Authorize(string username, string hashedPassword, string providedPass)
    {
        string salt = GenerateSalt(username);
        return _passwordHasher.VerifyHashedPassword(salt, hashedPassword, providedPass);
    }

    public string HashPassword(string username, string passwordToHash)
    {
        string salt = GenerateSalt(username);
        return _passwordHasher.HashPassword(salt, passwordToHash);
    }

    private string GenerateSalt(string username)
    {
        List<char> charList = username.ToList();
        charList.Sort();
        charList.Reverse();
        List<string> salt = new List<string>();
        salt.Add("9");
        foreach (var c in charList)
        {
            salt.Add(_abc.IndexOf(c).ToString());
        }
        salt.Add("9");
        return String.Concat(salt);
    }
}