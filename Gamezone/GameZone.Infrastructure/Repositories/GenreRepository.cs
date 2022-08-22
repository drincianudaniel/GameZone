using GameZone.Application;
using GameZone.Domain;
using GameZone.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly GameZoneContext _context;

        public GenreRepository(GameZoneContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Genre Genre)
        {
            _context.Genres.Add(Genre);
            await _context.SaveChangesAsync();
        }

        public async Task<Genre> ReturnByIdAsync(Guid id)
        {
            var genreToReturn = await _context.Genres.Include(x => x.Games)
                .Where(genre => genre.Id == id)
                .FirstOrDefaultAsync();

            return genreToReturn;
        }
        public async Task<IEnumerable<Genre>> ReturnAllAsync()
        {
            return await _context.Genres.Include(x => x.Games)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Genre genre)
        {
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }
    }
}
