using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VoiceCastMasters_api.Auth;
using VoiceCastMasters_api.Enums;
using VoiceCastMasters_api.Model;
using VoiceCastMasters_api.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace VoiceCastMasters_api.Controllers;

[ApiController, Route("access")]
public class AccessController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthorization _authorizer;

    public AccessController(IUserService userService, IAuthorization authorizer)
    {
        _userService = userService;
        _authorizer = authorizer;
    }

    [HttpPost("csirke")]
    public IActionResult TryThis([FromBody] User user)
    {
        Console.WriteLine(user);
        return Ok(user);
    }

    [HttpPost("registration")]
    public async Task<IActionResult> RegisterUser([FromBody] ActorDTO actor)
    {
        Console.WriteLine("lefutott");
        await _userService.AddUser(actor);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser()
    {
        string authorizationHeader = HttpContext.Request.Headers["Authorization"];
        var credentials = Encoding.UTF8.GetString((Convert.FromBase64String(authorizationHeader)));
        var parts = credentials.Split(":");
        var email = parts[0];
        var encodedPassword = parts[1];
        var user = await _userService.GetUserByEmail(email);

        if (user == null || user.Role == null)
        {
            return Unauthorized();
        }

        var authorized = _authorizer.Authorize(user, user.Password, encodedPassword);
        if (authorized == PasswordVerificationResult.Success)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
            };
            var roleName = Enum.GetName((typeof(Roles)), user.Role);
            claims.Add(new Claim(ClaimTypes.Role, 
                roleName ?? throw new InvalidOperationException("invalid role name")
                ));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal,
                authProperties);
            user.Password = "";
            
                
            if (user.Role == Roles.Director || user.Role == Roles.Actor)
            {
                //kill relational list by providing ActorDTO instead
                user = new ActorDTO((Actor)user);
            }
            return Ok(user);
        }

        return Unauthorized();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> LogoutUser()
    {
        try
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("User logged out successfully");
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Logout failed: {e.Message}");
        }
    }
    
    
}