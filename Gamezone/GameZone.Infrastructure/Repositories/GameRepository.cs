using GameZone.Application;
using GameZone.Domain.Models;
using GameZoneModels;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameZoneContext _context;

        public GameRepository(GameZoneContext context)
        {
            _context = context;
        }

        public async Task<Game> CreateAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task AddDeveloper(GameDeveloper gameDev)
        {
            _context.GameDevelopers.Add(gameDev);
            await _context.SaveChangesAsync();
        }

        public async Task<Game> ReturnByIdAsync(Guid id)
        {
            var gameToReturn = await _context.Games
                .Include(x => x.Users)
                .Include(x => x.Genres)
                .Include(x => x.Platforms)
                .Include(x => x.Developers)
                .Include(x => x.Comments).ThenInclude(m => m.User)
                .Include(x => x.Comments).ThenInclude(m => m.Replies).ThenInclude(m => m.User)
                .Include(x => x.Reviews).ThenInclude(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (gameToReturn == null)
            {
                throw new KeyNotFoundException("Game not found");
            }
            return gameToReturn;
        }

        public async Task<IEnumerable<Game>> ReturnAllAsync()
        {
            return await _context.Games
                .Include(x => x.Genres)
                .Include(x => x.Platforms)
                .Include(x => x.Developers)
                .Include(x => x.Comments).ThenInclude(m => m.User)
                .Include(x => x.Comments).ThenInclude(m => m.Replies).ThenInclude(m => m.User)
                .Include(x => x.Users)
                .Include(x => x.Reviews).ThenInclude(x => x.User)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task DeleteAsync(Game game)
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }

        public async Task CalculateTotalRatingAsync(Game game)
        {
            if(game.Reviews.Count != 0)
            {
                game.TotalRating = game.Reviews.Average(review => review.Rating);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddGenreListAsync(Game game, List<Genre> genres)
        {
            foreach (var genre in genres)
            {
                game.Genres.Add(genre);
            }

            await _context.SaveChangesAsync();
        }
        public async Task AddPlatformListAsync(Game game, List<Platform> platforms)
        {
            foreach (var platform in platforms)
            {
                game.Platforms.Add(platform);
            }

            await _context.SaveChangesAsync();
        }

        public async Task AddGenreAsync(Game game, Genre genre)
        {
            game.Genres.Add(genre);
            await _context.SaveChangesAsync();
        }

        public async Task AddPlatformAsync(Game game, Platform platform)
        {
            game.Platforms.Add(platform);
            await _context.SaveChangesAsync();
        }
        
        public async Task RemoveGenreAsync(Game game, Genre genre)
        {
            game.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }
        
        public async Task RemovePlatformAsync(Game game, Platform platform)
        {
            game.Platforms.Remove(platform);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>> GenerateTopList()
        {
            return await _context.Games.OrderByDescending(game => game.TotalRating).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Game>> SearchGameAsync(string searchString)
        {
            var games = from g in _context.Games select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                games = games.Where(s => s.Name.Contains(searchString));
            }

            return await games.AsNoTracking().ToListAsync();
        }
    }
}
