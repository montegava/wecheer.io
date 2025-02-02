using Wecheer.Core.Models;

namespace Wecheer.Core.Services;

public interface IStorageService
{
    void AddImage(ImageEntity entity);

    ImageEntity GetLastImage();
    
    long GetLastHourCount();
}