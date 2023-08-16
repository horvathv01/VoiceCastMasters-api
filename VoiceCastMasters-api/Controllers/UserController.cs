using Microsoft.AspNetCore.Mvc;

namespace VoiceCastMasters_api.Controllers;

[ApiController]
[Route("test")]
public class UserController : ControllerBase
{
    [HttpGet("id={id}")]
    public IActionResult GetUserByID(int id)
    {
        return Ok();
    }
}