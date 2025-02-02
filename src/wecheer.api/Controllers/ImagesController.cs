using Microsoft.AspNetCore.Mvc;
using Wecheer.Core.Mappers;
using Wecheer.Core.Models;
using Wecheer.Core.Services;

namespace Wecheer.Api.Controllers;

public class ImagesController : ControllerBase
{
    private readonly IStorageService _storageService;

    public ImagesController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    /// <summary>
    /// Add new image to the system
    /// </summary>
    /// <param name="imageDto"></param>
    /// <returns></returns>
    [HttpPost("api/images")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] CreateImageDto imageDto)
    {
        _storageService.AddImage(imageDto.ToEntity());
        return Created();
    }

    /// <summary>
    /// Get the latest image received
    /// </summary>
    /// <returns></returns>
    [HttpGet("api/images/latest")]
    [ProducesResponseType(typeof(ImageDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetLatest()
    {
        var image = _storageService.GetLastImage();

        if (image == null)
        {
            return NotFound();
        }

        return Ok(image.ToDto());
    }

    /// <summary>
    /// Get how many events have been received in the last hour
    /// </summary>
    /// <returns></returns>
    [HttpGet("api/images/count")]
    [ProducesResponseType(typeof(ImageCountDto), StatusCodes.Status200OK)]
    public IActionResult GetCount()
    {
        return Ok(new ImageCountDto { Count = _storageService.GetLastHourCount() });
    }

    /// <summary>
    /// Get statistics about the images received
    /// </summary>
    /// <returns></returns>
    [HttpGet("api/images/stats")]
    [ProducesResponseType(typeof(ImageStatDto), StatusCodes.Status200OK)]
    public IActionResult GetStats()
    {
        return Ok(new ImageStatDto
        {
            Count = _storageService.GetLastHourCount(),
            LatestImage = _storageService.GetLastImage()?.ToDto()
        });
    }
}