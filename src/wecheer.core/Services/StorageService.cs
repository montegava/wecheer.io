using System.Collections.Concurrent;
using Wecheer.Core.Models;

namespace Wecheer.Core.Services;

public class StorageService : IStorageService
{
    private static readonly ConcurrentQueue<ImageEntity> Events = new();

    public void AddImage(ImageEntity entity)
    {
        Events.Enqueue(entity);
    }

    public ImageEntity GetLastImage() => Events.LastOrDefault();

    public long GetLastHourCount()
    {
        var lastHour = DateTime.UtcNow.AddHours(-1);
        return Events.LongCount(e => e.ReceivedTime >= lastHour);
    }
}