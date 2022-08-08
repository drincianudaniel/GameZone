
using GameZone.Application.DTOs;

namespace GameZone.ConsoleProject
{
    public class ConsoleDisplay
    {
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
            Console.WriteLine("Comments");
            foreach (var comment in game.Comments)
            {
                Console.Write($"User: {comment.User.Username}: {comment.Content}");
            }
        }

        public static void DisplayDeveloper(DeveloperDto developer)
        {
            Console.WriteLine($"Id: {developer.Id} Name: {developer.Name} HeadQuarters: {developer.Headquarters}");
        }
        
        public static void DisplayGenre(GenreDto genre)
        {
            Console.WriteLine($"Id: {genre.Id} Name: {genre.Name}");
        }

        public static void DisplayPlatform(PlatformDto platform)
        {
            Console.WriteLine($"Id: {platform.Id} Name: {platform.Name}");
        }

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
                DisplayGenre(genre);
            }
        }

        public static void DisplayPlatforms(IEnumerable<PlatformDto> platforms)
        {
            var platformList = platforms.ToList();
            foreach (var platform in platformList)
            {
                DisplayPlatform(platform);
            }
        }

        public static void DisplayUser(UserDto user)
        {
            Console.WriteLine("");
            Console.WriteLine($"Id: {user.Id}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
            Console.WriteLine($"Role: {user.Role}");
            Console.Write("Favorite Games: ");
            foreach (var favoriteGame in user.Games)
            {
                Console.Write($"{favoriteGame.Name} ");
            }
            Console.WriteLine("");
        }

        public static void DisplayUsers(IEnumerable<UserDto> users)
        {
            var usersList = users.ToList();
            foreach(var user in usersList)
            {
                DisplayUser(user);
            }
            Console.WriteLine("");
        }
    }

}
