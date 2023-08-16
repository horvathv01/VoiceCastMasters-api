using Microsoft.AspNetCore.Mvc;
using VoiceCastMasters_api.DAL;
using VoiceCastMasters_api.Model;
using VoiceCastMasters_api.Services;

namespace VoiceCastMasters_api.Controllers;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    private IUserProvider _provider;

    public TestController(IUserProvider provider)
    {
        _provider = provider;
    }
    


    [HttpGet("firstTest")]
    public IActionResult GetRequest()
    {
        string message = "Hello world!";
        Console.WriteLine($"GET request received from {HttpContext.Request.Path}");
        return Ok(message);
    }

    [HttpGet("returnTest")]
    public IActionResult GetAll()
    {
        Console.WriteLine($"GET all request received from {HttpContext.Request.Path}");
        var result = _provider.GetActorsList();
        return Ok(result);
    }
}