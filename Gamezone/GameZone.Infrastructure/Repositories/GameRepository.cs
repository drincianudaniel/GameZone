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

        public void Create(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public Game ReturnById(Guid id)
        {
            var gameToReturn = _context.Games.Include("Genres").Include("Platforms").Include("Developers").Where(game => game.Id == id).FirstOrDefault();
            if (gameToReturn == null)
            {
                throw new KeyNotFoundException("Game not found");
            }
            return gameToReturn;
        }

        public IEnumerable<Game> ReturnAll()
        {
            var games = _context.Games.Include("Genres").Include("Platforms").Include("Developers").ToList();
            return games;
        }

        public void Delete(Guid id)
        {
            var gameToBeDeleted = ReturnById(id);
            _context.Games.Remove(gameToBeDeleted);
            _context.SaveChanges();
        }

        public void Update(Game game)
        {
            var gameAux = _context.Games.Where(game => game.Id == game.Id).FirstOrDefault();
            if(gameAux == null)
            {
                throw new NullReferenceException("Game doesnt exist");
            }
            _context.Games.Remove(gameAux);
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public void CalculateTotalRating(Game game)
        {
            game.TotalRating = game.Reviews.Average(review => review.Rating);
        }

      /*  public void AddDeveloper(int gameId, params Developer[] developers)
        {
            var game = ReturnById(gameId);
            foreach (var developer in developers)
            {
                game.AddDeveloper(developer);
            }
        }*/
        public void AddDeveloper(Guid gameId, Developer developer)
        {
            var game = ReturnById(gameId);
            game.AddDeveloper(developer);
        }

        public void AddGenre(Guid gameId, Genre genre)
        {
            var game = ReturnById(gameId);
            game.AddGenre(genre);
        }

        public void AddPlatform(Guid gameId, Platform platform)
        {
            var game = ReturnById(gameId);
            game.AddPlatform(platform);
        }

        public IEnumerable<Game> GenerateTopList()
        {
            return _context.Games.OrderByDescending(game => game.TotalRating).ToList();
        }
    }
}
