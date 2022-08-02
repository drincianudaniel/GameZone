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
                Console.WriteLine($"{developer.Id} {developer.DeveloperName}");
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
            Console.WriteLine(game.Name);
        }
    }
}
