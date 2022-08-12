using GameZone.Application;
using GameZone.Domain;
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

        public async Task CreateAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task<Game> ReturnByIdAsync(Guid id)
        {
            var gameToReturn = await _context.Games
                .Where(x => x.Id == id)
                .Include(x => x.Genres)
                .Include(x => x.Platforms)
                .Include(x => x.Developers)
                .Include(x => x.Comments)
                .Include(x => x.Users)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync();

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
                .Include(x => x.Comments)
                .Include(x => x.Users)
                .Include(x => x.Reviews)
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

        public async Task AddDeveloperListAsync(Game game, List<Developer> developers)
        {
            foreach (var developer in developers)
            {
                game.Developers.Add(developer);
            }

            await _context.SaveChangesAsync();
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
        public void AddDeveloper(Game game, Developer developer)
        {
            game.Developers.Add(developer);
            _context.SaveChanges();
        }

        public async Task AddGenreAsync(Game game, Genre genre)
        {
            game.AddGenre(genre);
            await _context.SaveChangesAsync();
        }

        public async Task AddPlatformAsync(Game game, Platform platform)
        {
            game.AddPlatform(platform);
            await _context.SaveChangesAsync();
        }

        /*public IEnumerable<Game> GenerateTopList()
        {
            return _context.Games.OrderByDescending(game => game.TotalRating).ToList();
        }*/
    }
}
