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
        public List<Game> Games { get; set; }

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

        public void CalculateTotalRating()
        {
            foreach (var game in Games)
            {
                game.TotalRating = game.Reviews.Average(review => review.Rating);
            }
        }

       /* public void AddDeveloperToGameByID(List<Developer> developersList, int id)
        {
            try
            {
                var developerToAdd = developersList.Where(developer => developer.Id == id).FirstOrDefault();
                if (Developers.Any(item => item.Id == developerToAdd.Id))
                {
                    throw new DuplicateWaitObjectException("Object is already in list");
                }
                Developers.Add(developerToAdd);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException($"Developer with {id} doesn't exist.");
            }
        }
        public void AddGenreToGameByID(List<Genre> genres, int id)
        {
            try
            {
                var genreToAdd = genres.Where(genre => genre.Id == id).FirstOrDefault();
                Genres.Add(genreToAdd);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException($"Genre with {id} doesn't exist.");
            }
        }

        public void AddPlatformToGameByID(List<Platform> platforms, int id)
        {
            try
            {
                var platformsToAdd = platforms.Where(platform => platform.Id == id).FirstOrDefault();
                Platforms.Add(platformsToAdd);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException($"Platform with {id} doesn't exist.");
            }
        }*/

        public static List<Game> GenerateTopList(List<Game> gameList)
        {
            try
            {
                return gameList.OrderByDescending(game => game.TotalRating).ToList();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException($"Game list is null");
            }
        }
    }
}
