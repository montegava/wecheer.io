using Wecheer.Core.Models;

namespace Wecheer.Core.Services;

public static class StorageService
{
    private static List<ImageEntity> Events = new List<ImageEntity>();

    public static void AddImage(ImageEntity entity)
    {
        Events.Add(entity);
    }

    public static ImageEntity GetLastImage() => Events.LastOrDefault();

    public static long GetLastHourCount()
    {
        var lastHour = DateTime.UtcNow.AddHours(-1);
        return Events.LongCount(e => e.ReceivedTime >= lastHour);
    }
}