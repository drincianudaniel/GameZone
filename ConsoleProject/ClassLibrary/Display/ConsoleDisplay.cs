using GameZone.Domain.Exceptions;
using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Domain.Display
{
    public class ConsoleDisplay
    {
        private StringBuilder sb = new StringBuilder();
        public void DisplayUser(User user)
        {
            Console.WriteLine("");
            Console.WriteLine($"Id: {user.id}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Name: {user.FirstName} {user.LastName}");

            if (user.FavoriteGames.Count > 0)
            {
                Console.Write("Favorite Games: ");
                foreach (var favoriteGame in user.FavoriteGames)
                {
                    sb.Append(favoriteGame.Name);
                    if (favoriteGame != user.FavoriteGames.Last())
                    {
                        sb.Append(", ");
                    }
                }
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }

            if (user.userReviews.Count > 0)
            {
                Console.WriteLine("User Reviews: ");
                foreach (var userReview in user.userReviews)
                {
                    Console.WriteLine($"Game: {userReview.ReviewedGame.Name} Rating: {userReview.Rating}");
                    Console.WriteLine($"Review content: {userReview.Content}");
                    Console.WriteLine("---------------");
                }
            }
            Console.WriteLine("==============================================================");
        }
        public void DisplayGame(Game game)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine($"Id: {game.id}");
                Console.WriteLine($"Name: {game.Name}");
                Console.WriteLine($"Release date: {game.ReleaseDate.ToLongDateString()}");
                Console.WriteLine($"Rating: {game.TotalRating}");
                Console.WriteLine($"Game details: {game.GameDetails}");

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

                if (game.Reviews.Count > 0)
                {
                    Console.WriteLine("Reviews: ");
                    foreach (var review in game.Reviews)
                    {
                        Console.Write(review.Reviewer.LastName + " " + review.Reviewer.FirstName + ": ");
                        Console.Write(review.Rating + " ");
                        Console.WriteLine(review.Content);
                    }
                }

                if (game.Comments.Count > 0)
                {
                    Console.WriteLine("Comments: ");
                    foreach (var comment in game.Comments)
                    {
                        Console.Write(comment.id + ". " + comment.CommentOwer.Username + ": ");
                        Console.WriteLine(comment.Content);

                        if (comment.Replies.Count > 0)
                        {
                            Console.WriteLine("Replies: ");
                            foreach (var reply in comment.Replies)
                            {
                                Console.WriteLine($"Reply from {reply.ReplyOwner.Username}: {reply.Content}");
                            }
                        }
                    }
                }
                Console.WriteLine("==============================================================");
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("Game not found");
            }
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Welcome. Please enter your command: ");
            Console.WriteLine("1. Display all games");
            Console.WriteLine("2. Display all users");
            Console.WriteLine("3. Display game by id");
            Console.WriteLine("4. Create a game entity");
            Console.WriteLine("5. Manage Game");
            Console.WriteLine("6. Display Game TOP");
        }

        public void DisplayGameMenu()
        {
            Console.WriteLine("1. Add Developer to game");
            Console.WriteLine("2. Add Genre to game");
            Console.WriteLine("3. Add Platform to game");
            Console.WriteLine("4. Add comment to game");
        }

        public void DisplayAllGames(List<Game> gamelist)
        {
            try
            {
                Console.WriteLine("");
                if (gamelist.Count == 0)
                {
                    throw new GameException("Game list empty");
                }
                foreach (var game in gamelist)
                {
                    DisplayGame(game);
                }
            }
            catch (GameException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            #if DEBUG
            finally
            {
                Debug.Write("function executed");
                Console.WriteLine("Function display all games executed");
            }
            #endif
        }
        public void DisplayAllUsers(List<User> users)
        {
            try
            {
                Console.WriteLine("");
                if (users.Count == 0)
                {
                    throw new UserException("Users list empty");
                }
                foreach (var user in users)
                {
                    DisplayUser(user);
                }
            }
            catch(UserException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            #if DEBUG
            finally
            {
                Debug.Write("function executed");
                Console.WriteLine("Function display all users executed");
            }
            #endif
        }

        public void DisplayDevelopers(List<Developer> developers)
        {
            if (developers.Count == 0)
            {
                throw new NullReferenceException("Developers list is null");
            }
            foreach(var developer in developers)
            {
                Console.WriteLine($"{developer.id} {developer.Name}");
            }
        }

        public void DisplayGenres(List<Genre> genres)
        {
            if (genres.Count == 0)
            {
                throw new NullReferenceException("Genres list is null");
            }
            foreach (var genre in genres)
            {
                Console.WriteLine($"{genre.id} {genre.Name}");
            }
        }

        public void DisplayPlatforms(List<Platform> platforms)
        {
            if (platforms.Count == 0)
            {
                throw new NullReferenceException("Platforms list is null");
            }
            foreach (var platform in platforms)
            {
                Console.WriteLine($"{platform.id} {platform.Name}");
            }
        }
    }
}
