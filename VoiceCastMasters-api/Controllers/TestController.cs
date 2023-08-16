using Microsoft.AspNetCore.Mvc;

namespace VoiceCastMasters_api.Controllers;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{


    [HttpGet("firstTest")]
    public IActionResult GetRequest()
    {
        string message = "Hello world!";
        Console.WriteLine($"GET request received from {HttpContext.Request.Path}");
        return Ok(message);
    } 
}