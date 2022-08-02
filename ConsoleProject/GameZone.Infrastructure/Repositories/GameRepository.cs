using GameZone.Infrastructure.Interfaces;
using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private List<Game> Games { get; set; }

        public GameRepository()
        {
            Games = new List<Game>();
        }

        public void Create(Game game)
        {
            Games.Add(game);
        }

        public Game ReturnById(int id)
        {
            var gameToReturn = Games.Find(game => game.Id == id);
            if (gameToReturn == null)
            {
                throw new KeyNotFoundException("Game not found");
            }
            return gameToReturn;
        }

        public List<Game> ReturnAll()
        {
            if (Games.Count() == 0)
            {
                throw new NullReferenceException("Games list is null");
            }
            return Games;
        }

        public void Delete(int id)
        {
            var gameToBeDeleted = ReturnById(id);
            Games.Remove(gameToBeDeleted);
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
            return Games.OrderByDescending(game => game.TotalRating).ToList();
        }
    }
}
