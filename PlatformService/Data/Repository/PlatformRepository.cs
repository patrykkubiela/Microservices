using System.Collections.Generic;
using PlatformService.Data.Interfaces;
using PlatformService.Models;

namespace PlatformService.Data.Repository
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly PlatformDbContext _context;

        public PlatformRepository(PlatformDbContext context)
        {
            _context = context;
        }

        public void CreatePlatform(Platform platform)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            throw new System.NotImplementedException();
        }

        public Platform GetPlatform(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}