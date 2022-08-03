
using GameZone.Application.DTOs;

namespace GameZone.ConsoleProject
{
    public class ConsoleDisplay
    {
        public static void DisplayGames(IEnumerable<GameDto> games)
        {
            var gamelist = games.ToList();
            foreach (var game in gamelist)
            {
                DisplayGame(game);
            }
        }
        public static void DisplayDevelopers(IEnumerable<DeveloperDto> developers)
        {
            var developerList = developers.ToList();
            foreach(var developer in developerList)
            {
                DisplayDeveloper(developer);
            }
        }

        public static void DisplayGenres(IEnumerable<GenreDto> genres)
        {
            var genresList = genres.ToList();
            foreach (var genre in genresList)
            {
                Console.WriteLine($"{genre.Id} {genre.Name}");
            }
        }

        public static void DisplayPlatforms(IEnumerable<PlatformDto> platforms)
        {
            var platformList = platforms.ToList();
            foreach (var developer in platformList)
            {
                Console.WriteLine($"{developer.Id} {developer.Name}");
            }
        }

        public static void DisplayDeveloper(DeveloperDto developer)
        {
            Console.WriteLine($"Id: {developer.Id} Name: {developer.Name} HeadQuarters: {developer.Headquarters}");
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
