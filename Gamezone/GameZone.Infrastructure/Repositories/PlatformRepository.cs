﻿using GameZone.Application;
using GameZone.Domain;
using GameZoneModels;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Infrastructure.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly GameZoneContext _context;
        public PlatformRepository(GameZoneContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Platform platform)
        {
            _context.Platforms.Add(platform);
            await _context.SaveChangesAsync();
        }

        public async Task<Platform> ReturnByIdAsync(Guid id)
        {
            var platformToReturn = _context.Platforms.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (platformToReturn == null)
            {
                throw new KeyNotFoundException("Platform not found");
            }
            return await platformToReturn;
        }
        public async Task<IEnumerable<Platform>> ReturnAllAsync()
        {
            return await _context.Platforms.ToListAsync();
        }
        public async Task UpdateAsync(Platform platform)
        {
            _context.Platforms.Update(platform);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Platform platform)
        {
            _context.Platforms.Remove(platform);
            await _context.SaveChangesAsync();
        }
    }
}
