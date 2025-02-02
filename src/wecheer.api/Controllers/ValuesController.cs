using Microsoft.AspNetCore.Mvc;

namespace MyServerlessApi.Controllers;

public class ValuesController : ControllerBase
{
    [HttpPost("api/images")]
    public IActionResult Post([FromBody] ImageEvent imageEvent)
    {
        imageEvent.ReceivedTime = DateTime.UtcNow;
        StorageService.Events.Add(imageEvent);
        return Ok();
    }

    [HttpGet("api/images/latest")]
    public IActionResult GetLatest()
    {
        return Ok(StorageService.LastEvent);
    }

    [HttpGet("api/images/count")]
    public IActionResult GetCount()
    {
        var oneHourAgo = DateTime.UtcNow.AddHours(-1);
        var count = StorageService.Events.Count(e => e.ReceivedTime >= oneHourAgo);
        return Ok(new { Count = count });
    }
}

// Models/ImageEvent.cs

// Services/StorageService.cs