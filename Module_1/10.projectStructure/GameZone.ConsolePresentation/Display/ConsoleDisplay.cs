using GameZone.Domain.Exceptions;
using System.Diagnostics;
using System.Text;
using GameZone.Application;
using GameZone.Application.Developers.Queries.GetDevelopersList;
using GameZone.Application.Genres.Queries.GetGenresList;
using GameZone.Application.Platforms.Queries.GetPlatformsList;
using GameZone.Application.Games.Queries.GetGameById;

namespace GameZone.ConsoleProject
{
    public class ConsoleDisplay
    {
        private StringBuilder sb = new StringBuilder();
        public static void DisplayDevelopers(IEnumerable<DevelopersListVm> developers)
        {
            var developerList = developers.ToList();
            foreach(var developer in developerList)
            {
                Console.WriteLine($"{developer.Id} {developer.DeveloperName} {developer.Headquarters}");
            }
        }

        public static void DisplayGenres(IEnumerable<GenresListVm> genres)
        {
            var genresList = genres.ToList();
            foreach (var genre in genresList)
            {
                Console.WriteLine($"{genre.Id} {genre.GenreName}");
            }
        }

        public static void DisplayPlatforms(IEnumerable<PlatformsListVm> platforms)
        {
            var platformList = platforms.ToList();
            foreach (var developer in platformList)
            {
                Console.WriteLine($"{developer.Id} {developer.PlatformName}");
            }
        }

        public static void DisplayGame(GameDto game)
        {
            Console.WriteLine($"Id: {game.Id}");
            Console.WriteLine($"Name: {game.Name}");
            Console.WriteLine($"Date: {game.ReleaseDate.ToLongDateString()}");
            Console.WriteLine($"Game Details: {game.GameDetails}");

            Console.Write("Developers: ");
            foreach (var developer in game.Developers)
            {
                Console.Write(developer.Name + " ");
            }

            Console.WriteLine(" ");
            Console.Write("Genres: ");
            foreach (var genre in game.Genres)
            {
                Console.Write(genre.Name + " ");
            }

            Console.WriteLine(" ");
            Console.Write("Platforms: ");
            foreach (var platform in game.Platforms)
            {
                Console.Write(platform.Name + " ");
            }
            Console.WriteLine(" ");
        }
    }
}
