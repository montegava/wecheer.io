using Wecheer.Core.Models;

namespace Wecheer.Core.Mappers;

public static class ImageMapper
{
    public static ImageDto ToDto(this ImageEntity entity)
    {
        if (entity == null)
        {
            return null;
        }

        return new ImageDto
        {
            ImageUrl = entity.ImageUrl,
            Description = entity.Description,
            ReceivedTime = entity.ReceivedTime
        };
    }
    public static ImageEntity ToEntity(this CreateImageDto dto)
    {
        if (dto == null)
        {
            return null;
        }

        return new ImageEntity
        {
            ImageUrl = dto.ImageUrl,
            Description = dto.Description,
            ReceivedTime = DateTime.UtcNow
        };
    }
}