﻿using System.Net;
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
    private IActorService _actorService;
    public UserController(IActorService actorService)
    {
        _actorService = actorService;
    }
    [HttpGet]
    public async Task<IActionResult> GetUserById()
    {
        long id = 0;
        try
        {
            Uri deleteUri = new Uri(Request.GetDisplayUrl());
            id = (long)Convert.ToDouble(HttpUtility.ParseQueryString(deleteUri.Query).Get("userid"));
            if (id == 0) return BadRequest("No ID provided");
            Actor actor = await _actorService.GetActorByID(id);
            return Ok(actor);
        }
        catch (Exception e)
        {
            return NotFound($"User with such ID ({id}) is not found");
        }
        
    }
    [HttpGet("actors")]
    public async Task<IActionResult> GetAllActors()
    {
        List<Actor>? actorsList = await _actorService.GetActorsList();
        if (actorsList is { Count: > 0 }) return Ok(actorsList);
        return NotFound("No users in database");
    }
    
    [HttpPut("register")]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        try
        {
            ActorDTO newUser = new ActorDTO(user);
            if (await _actorService.AddActor(newUser)) return Ok($"User created successfully with ID {user.ID}.");
            return new ObjectResult(HttpStatusCode.BadGateway);
        }
        catch (Exception e)
        {
            return BadRequest("User might have already been created.");
        }
        
    }

    [HttpPut("actor/update")]
    public async Task<IActionResult> UpdateUser([FromBody] ActorDTO actor)
    {
        
        Uri deleteUri = new Uri(Request.GetDisplayUrl());
        long id = (long)Convert.ToDouble(HttpUtility.ParseQueryString(deleteUri.Query).Get("userid"));
        if (id == 0) return BadRequest("No ID provided");
        DateTime birthDate = DateTime.MinValue;
        DateTime.TryParse(actor.BirthDate, out birthDate);
        User user = new Actor(actor.Name, birthDate, actor.Email, actor.Password, actor.Phone, actor.SampleURL,
            actor.ProfilePicture);
        if (await _actorService.UpdateUser(id, (Actor)user)) return Ok($"Successfully updated user with ID {user.ID}.");
        return NotFound($"User with such ID ({user.ID}) is not found");
    }
    
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteActor()
    {
        Uri deleteUri = new Uri(Request.GetDisplayUrl());
        try
        {
            long id = (long)Convert.ToDouble(HttpUtility.ParseQueryString(deleteUri.Query).Get("userid"));
            if (await _actorService.DeleteUser(id)) return Ok($"User with ID {id} is successfully removed from the database");
            return NotFound("No user with such id");
        }
        catch (Exception e)
        {
            return new ObjectResult(HttpStatusCode.BadRequest);
        }
    }
}