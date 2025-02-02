using Microsoft.AspNetCore.Mvc;
using Wecheer.Core.Models;
using Wecheer.Core.Services;

namespace Wecheer.Api.Controllers;

public class ImagesController : ControllerBase
{
    /// <summary>
    /// Add new image to the system
    /// </summary>
    /// <param name="createImageDto"></param>
    /// <returns></returns>
    [HttpPost("api/images")]
    [ProducesResponseType( StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] CreateImageDto createImageDto)
    {
        createImageDto.ReceivedTime = DateTime.UtcNow;
        StorageService.Events.Add(createImageDto);
        return Ok();
    }

    [HttpGet("api/images/latest")]
    public IActionResult GetLatest()
    {
        return Ok(StorageService.LastDto);
    }

    [HttpGet("api/images/count")]
    public IActionResult GetCount()
    {
        var oneHourAgo = DateTime.UtcNow.AddHours(-1);
        var count = StorageService.Events.Count(e => e.ReceivedTime >= oneHourAgo);
        return Ok(new { Count = count });
    }
}