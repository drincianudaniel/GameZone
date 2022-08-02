using GameZone.Infrastructure.Interfaces;
using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Repositories
{
    public class InMemoryGameRepository : IGameRepository
    {
        private readonly List<Game> _games;

        public InMemoryGameRepository()
        {
            _games = new List<Game>();
        }

        public void Create(Game game)
        {
            _games.Add(game);
        }

        public Game ReturnById(int id)
        {
            var gameToReturn = _games.Find(game => game.Id == id);
            if (gameToReturn == null)
            {
                throw new KeyNotFoundException("Game not found");
            }
            return gameToReturn;
        }

        public List<Game> ReturnAll()
        {
            if (_games.Count() == 0)
            {
                throw new NullReferenceException("Games list is null");
            }
            return _games;
        }

        public void Delete(int id)
        {
            var gameToBeDeleted = ReturnById(id);
            _games.Remove(gameToBeDeleted);
        }

        public void Update(int id, Game game)
        {
            var gameToBeUpdated = ReturnById(id);
            gameToBeUpdated.Name = game.Name;
        }

        public void CalculateTotalRating(Game game)
        {
            game.TotalRating = game.Reviews.Average(review => review.Rating);
        }

        public void AddDeveloper(int gameId, Developer developer)
        {
            var game = ReturnById(gameId);
            game.Developers.Add(developer);
        }

        public void AddGenre(int gameId, Genre genre)
        {
            var game = ReturnById(gameId);
            game.Genres.Add(genre);
        }

        public void AddPlatform(int gameId, Platform platform)
        {
            var game = ReturnById(gameId);
            game.Platforms.Add(platform);
        }

        public List<Game> GenerateTopList()
        {
            return _games.OrderByDescending(game => game.TotalRating).ToList();
        }
    }
}
