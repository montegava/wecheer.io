using Wecheer.Core.Models;

namespace Wecheer.Core.Services;

public static class StorageService
{
    public static List<CreateImageDto> Events = new List<CreateImageDto>();
    public static CreateImageDto LastDto => Events.LastOrDefault();
}