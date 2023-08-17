using System.Net;
using System.Runtime.InteropServices.JavaScript;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using VoiceCastMasters_api.Model;
using VoiceCastMasters_api.Services;

namespace VoiceCastMasters_api.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private IUserProvider _userProvider;
    public UserController(IUserProvider userProvider)
    {
        _userProvider = userProvider;
    }
    [HttpGet]
    public IActionResult GetUserByID()
    {
        try
        {
            Uri deleteUri = new Uri(Request.GetDisplayUrl());
            long id = (long)Convert.ToDouble(HttpUtility.ParseQueryString(deleteUri.Query).Get("userid"));
            User user = _userProvider.GetUserById(id);
            return Ok(user);
        }
        catch (Exception e)
        {
            return new ObjectResult(HttpStatusCode.BadRequest);
        }
        
    }
    [HttpGet("actors")]
    public IActionResult GetAllActors()
    {
        List<Actor> actorsList = _userProvider.GetActorsList();
        if (actorsList.Count > 0) return Ok(actorsList);
        return NotFound("No users in database");
    }
    
    [HttpPut("actor/update")]
    public IActionResult CreateUser(User user)
    {
        try
        {
            if (_userProvider.RegisterUser(user)) return Ok("User created successfully");
            return new ObjectResult(HttpStatusCode.BadGateway);
        }
        catch (Exception e)
        {
            return new ObjectResult(HttpStatusCode.BadRequest);
        }
        
    }
    
    [HttpDelete("delete")]
    public IActionResult DeleteActor()
    {
        Uri deleteUri = new Uri(Request.GetDisplayUrl());
        try
        {
            long id = (long)Convert.ToDouble(HttpUtility.ParseQueryString(deleteUri.Query).Get("userid"));
            if (_userProvider.DeleteUser(id)) return Ok("User is successfully removed from the database");
            return NotFound("No user with such id");
        }
        catch (Exception e)
        {
            return new ObjectResult(HttpStatusCode.BadRequest);
        }
    }
}