namespace MyServerlessApi.Controllers;

public class ImageEvent
{
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public DateTime? ReceivedTime { get; set; }
}