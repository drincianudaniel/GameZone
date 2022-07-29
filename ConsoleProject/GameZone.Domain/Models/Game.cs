using GameZone.Domain.Exceptions;
using GameZone.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels 
{
    public class Game : Entity
    {
        private static int serial = 1;
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double TotalRating { get; set; }
        public string GameDetails { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Platform> Platforms { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Comment> Comments { get; set; }
        public Game(string name, DateTime releaseDate, string gameDetails)
        {
            this.Name = name;
            this.ReleaseDate = releaseDate;
            this.GameDetails = gameDetails;
            this.Id = serial++;
        }

        public void CalculateTotalRating()
        {
            TotalRating = Reviews.Average(review => review.Rating);
        }
        public static Game ReturnGameById(List<Game> gameslist, int id)
        {
            try
            {
                Game gameToReturn = null;
                foreach (var game in gameslist)
                {
                    gameToReturn = gameslist.Where(game => game.Id == id).FirstOrDefault();
                }
                return gameToReturn;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException($"Game with id {id} doesn't exist.");
            }
        }

        public void AddDeveloperToGameByID(List<Developer> developersList, int id)
        {
            try
            {
                var developerToAdd = developersList.Where(developer => developer.Id == id).FirstOrDefault();
                if(Developers.Any(item => item.Id == developerToAdd.Id))
                {
                    throw new DuplicateWaitObjectException("Object is already in list");
                }
                Developers.Add(developerToAdd);
            } catch (NullReferenceException)
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
        }

        public static List<Game> GenerateTopList(List<Game> gameList)
        {
            try
            { 
                return gameList.OrderByDescending(game => game.TotalRating).ToList();
            } catch (NullReferenceException)
            {
                throw new NullReferenceException($"Game list is null");
            }
        }

        public static Game CreateGame(string name, int year, int month, int day, string gameDetails) 
        {
            var game = new Game(name, new DateTime(year, month, day), gameDetails);
            game.Developers = new List<Developer> { };
            game.Genres = new List<Genre> { };
            game.Platforms = new List<Platform> { };
            game.Reviews = new List<Review>();
            game.Comments = new List<Comment>();
            return game;
        }
    }
}
