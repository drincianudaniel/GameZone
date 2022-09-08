using GameZone.Application;
using GameZone.Domain;
using GameZone.Domain.Models;
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

        public async Task CreateAsync(Developer Developer)
        {
            _context.Developers.Add(Developer);
        }

        public async Task<Developer> ReturnByIdAsync(Guid id)
        {
            var developerToReturn = await _context.Developers.Include(x => x.Games)
                .Where(developer => developer.Id == id)
                .FirstOrDefaultAsync();

            return developerToReturn;
        }
        public async Task<IEnumerable<Developer>> ReturnAllAsync()
        {
            return await _context.Developers
                .Include(x => x.Games)
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
        public async Task UpdateAsync(Developer developer)
        {
            _context.Update(developer);
        }
        public async Task DeleteAsync(Developer developer)
        {
            _context.Developers.Remove(developer);
        }
    }
}