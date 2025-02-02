namespace MyServerlessApi.Controllers;

public static class StorageService
{
    public static List<ImageEvent> Events = new List<ImageEvent>();
    public static ImageEvent LastEvent => Events.LastOrDefault();
}