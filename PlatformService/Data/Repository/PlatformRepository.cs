using System;
using System.Collections.Generic;
using System.Linq;
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
            if (platform == null)
                throw new ArgumentException("Parameter should be not empty.", nameof(platform));

            _context.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatform(int id)
        {
            return _context.Platforms.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}