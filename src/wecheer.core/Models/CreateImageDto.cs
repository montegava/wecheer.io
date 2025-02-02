namespace Wecheer.Core.Models;

public class CreateImageDto
{
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public DateTime? ReceivedTime { get; set; }
}