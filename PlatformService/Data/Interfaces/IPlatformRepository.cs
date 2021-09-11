using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Data.Interfaces
{
    public interface IPlatformRepository
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatform(int id);
        void CreatePlatform(Platform platform);
    }
}