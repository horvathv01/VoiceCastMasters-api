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
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace VoiceCastMasters_api.Controllers;

[ApiController, Route("access")]
public class AccessController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthorization _authorizer;
    private readonly IActorService _actorService;

    public AccessController(IUserService userService, IAuthorization authorizer, IActorService actorService)
    {
        _userService = userService;
        _actorService = actorService;
        _authorizer = authorizer;
    }

    [HttpPost("registration")]
    public async Task<IActionResult> RegisterActor([FromBody] ActorDTO actor)
    {
        var registeredUser = _userService.GetUserByEmail(actor.Email);
        if (registeredUser != null)
        {
            return Conflict("This email has already been registered");
        }
        if (actor.Password == "")
        {
            return Conflict("Password is required");
        }
        
        string newPassword = _authorizer.HashPassword(actor, actor.Password);
        actor.Password = newPassword;
        _actorService.AddActor(actor);
        return Ok("Registration was successful.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser()
    {
        string authorizationHeader = HttpContext.Request.Headers["Authorization"];
        
        var base64String = Convert.FromBase64String(authorizationHeader);
        var credentials = Encoding.UTF8.GetString(base64String);
        var parts = credentials.Split(":");
        var email = parts[0];
        var encodedPassword = parts[1];
        var user = _userService.GetUserByEmail(email);
        
        if (user == null || user.Role == null)
        {
            return Unauthorized("Provided credentials are not valid");
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

            var userToSend = new ActorDTO((Actor)user);
            userToSend.Password = "";
                
            if (user.Role == Roles.Director || user.Role == Roles.Actor)
            {
                //kill relational list by providing ActorDTO instead
                //user = new ActorDTO((Actor)user);
            }
            return Ok(userToSend);
        }

        return Unauthorized("Provided credentials are not valid");
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> LogoutUser()
    {
        try
        {
            string userName = HttpContext.User.Identity.Name;
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Console.WriteLine($"{userName} logged out successfully.");
            return Ok($"{userName} logged out successfully");
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Logout failed: {e.Message}");
        }
    }

    [HttpGet("test")]
    //[Authorize]
    [Authorize(Roles = "Actor")]
    public IActionResult TestLoginFunctionality()
    {
        Console.WriteLine("test lefutott");
        string userName = HttpContext.User.Identity.Name;
        Console.WriteLine(userName + " login tested.");
        return Ok($"Cookie works as intended. User Name: {userName}");
    }
    
    
}