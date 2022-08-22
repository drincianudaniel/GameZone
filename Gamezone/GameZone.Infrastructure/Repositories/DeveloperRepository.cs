using GameZone.Application;
using GameZone.Domain;
using GameZoneModels;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Infrastructure.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly GameZoneContext _context;

        public DeveloperRepository(GameZoneContext context)
        {
            _context = context;
        }

        public async Task<Developer> CreateAsync(Developer developer)
        {
            _context.Developers.Add(developer);
            await _context.SaveChangesAsync();
            return developer;
        }

        public async Task<Developer> ReturnByIdAsync(Guid id)
        {
            var developerToReturn = await _context.Developers
                .FirstOrDefaultAsync(developer => developer.Id == id);

            if (developerToReturn == null)
            {
                throw new KeyNotFoundException("Developer not found");
            }

            return developerToReturn;
        }
        public async Task<IEnumerable<Developer>> ReturnAllAsync()
        {
            return await _context.Developers
                .Include(x => x.Games)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task UpdateAsync(Developer developer)
        {
            _context.Update(developer);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Developer developer)
        {
            _context.Developers.Remove(developer);
            await _context.SaveChangesAsync();
        }
    }
}