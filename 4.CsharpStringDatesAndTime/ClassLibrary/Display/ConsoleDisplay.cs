using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Domain.Display
{
    public class ConsoleDisplay
    {
        public void displayRegularUserInfo(RegularUser user)
        {
            Console.WriteLine($"Id: {user.id}");
            Console.WriteLine($"Email: {user.email}");
            Console.WriteLine($"Username: {user.username}");
            Console.WriteLine("Name: " + user.firstName + " " + user.lastName);
            if (user.FavoriteGames.Count > 0)
            {
                Console.WriteLine("Favorite Games: ");
                foreach (var favoriteGame in user.FavoriteGames)
                {
                    Console.Write(favoriteGame.name + " ");
                }
            }
            Console.WriteLine("");
            if (user.userReviews.Count > 0)
            {
                Console.WriteLine("User Reviews: ");
                foreach (var userReview in user.userReviews)
                {
                    Console.WriteLine("Game: " + userReview.reviewedGame.name + " Rating: " + userReview.rating);
                    Console.WriteLine(userReview.content + " ");
                    Console.WriteLine("---------------");
                }
            }
            Console.WriteLine("==============================================================");
        }
        public void displayGame(Game game)
        {
            Console.WriteLine("Id: " + game.id);
            Console.WriteLine("Name: " + game.name);
            Console.WriteLine("Release date: " + game.releaseDate.ToLongDateString());
            Console.WriteLine("Rating: " + game.calculateTotalRating());
            Console.WriteLine("Game details: " + game.gameDetails);

            Console.Write("Developers: ");
            foreach (var developer in game.Developers)
            {
                Console.Write(developer.name + " ");
            }

            Console.WriteLine(" ");
            Console.Write("Genres: ");
            foreach (var genre in game.Genres)
            {
                Console.Write(genre.name + " ");
            }

            Console.WriteLine(" ");
            Console.Write("Platforms: ");
            foreach (var platform in game.Platforms)
            {
                Console.Write(platform.name + " ");
            }
            Console.WriteLine(" ");

            if (game.Reviews.Count > 0)
            {
                Console.WriteLine("Reviews: ");
                foreach (var review in game.Reviews)
                {
                    Console.Write(review.reviewer.lastName + " " + review.reviewer.firstName + ": ");
                    Console.Write(review.rating + " ");
                    Console.WriteLine(review.content);
                }
            }

            if (game.Comments.Count > 0)
            {
                Console.WriteLine("Comments: ");
                foreach (var comment in game.Comments)
                {
                    Console.Write(comment.id + ". " + comment.commentOwer.username + ": ");
                    Console.WriteLine(comment.content);

                    if (comment.replies.Count > 0)
                    {
                        Console.WriteLine("Replies: ");
                        foreach (var reply in comment.replies)
                        {
                            Console.WriteLine("Reply from " + reply.replyOwner.username + ": " + reply.content);
                        }
                    }
                }
            }
            Console.WriteLine("==============================================================");
        }
    }
}
