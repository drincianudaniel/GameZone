using GameZone.Application;
using GameZone.Domain;
using GameZoneModels;
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

        public async Task<Genre> CreateAsync(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> ReturnByIdAsync(Guid id)
        {
            var genreToReturn = await _context.Genres.Include(x => x.Games)
                .Where(genre => genre.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (genreToReturn == null)
            {
                throw new KeyNotFoundException("Genre not found");
            }
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
