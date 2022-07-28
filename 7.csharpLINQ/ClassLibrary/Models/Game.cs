using GameZone.Domain.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels 
{
    public class Game
    {
        private static int serial = 1;
        public int id { get; set; }
        public string name { get; set; }
        public DateTime releaseDate { get; set; }
        public double totalRating { get; set; }
        public string gameDetails { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Platform> Platforms { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Comment> Comments { get; set; }
        public Game(string name, DateTime releaseDate, string gameDetails)
        {
            this.name = name;
            this.releaseDate = releaseDate;
            this.gameDetails = gameDetails;
            this.id = serial++;
        }

        public void CalculateTotalRating()
        {
            totalRating = Reviews.Average(review => review.rating);
        }
        public static Game ReturnGameById(List<Game> gameslist, int id)
        {
            try
            {
                Game gameToReturn = null;
                foreach (var game in gameslist)
                {
                    gameToReturn = gameslist.Where(game => game.id == id).FirstOrDefault();
                }
                return gameToReturn;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException($"Game with id {id} doesn't exist.");
            }
        }

        public void AddDeveloperToGameByID(List<Developer> developers, int id)
        {
            try
            {
                var developerToAdd = developers.Where(developer => developer.id == id).FirstOrDefault();
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
                var genreToAdd = genres.Where(genre => genre.id == id).FirstOrDefault();
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
                var platformsToAdd = platforms.Where(platform => platform.id == id).FirstOrDefault();
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
                return gameList.OrderByDescending(game => game.totalRating).ToList();
            } catch (NullReferenceException)
            {
                throw new NullReferenceException($"Game list is null");
            }
        }
    }
}
