using GameZone.Application;
using GameZone.Domain;
using GameZone.Domain.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

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
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Genre>> ReturnPagedAsync(int? page, int pageSize, string searchString)
        {
            int pageNumber = (page ?? 1);

            var genres = from g in _context.Genres select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                genres = genres.Where(p => p.Name!.Contains(searchString));
            }

            return await genres
                .AsNoTracking()
                .OrderByDescending(genre => genre.CreatedAt)
                .ToPagedListAsync(pageNumber, pageSize);
        }

        public async Task<int> CountAsync(string searchString)
        {
            var genres = from g in _context.Genres select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                genres = genres.Where(p => p.Name!.Contains(searchString));
            }

            return await genres.CountAsync();
        }

        public async Task UpdateAsync(Genre genre)
        {
            _context.Genres.Update(genre);
        }
        public async Task DeleteAsync(Genre genre)
        {
            _context.Genres.Remove(genre);
        }
    }
}
