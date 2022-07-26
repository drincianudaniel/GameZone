﻿using GameZone.Domain.Exceptions;
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
        public void displayUser(User user)
        {
            Console.WriteLine("");
            Console.WriteLine($"Id: {user.id}");
            Console.WriteLine($"Email: {user.email}");
            Console.WriteLine($"Username: {user.username}");
            Console.WriteLine($"Name: {user.firstName} {user.lastName}");

            if (user.FavoriteGames.Count > 0)
            {
                Console.Write("Favorite Games: ");
                foreach (var favoriteGame in user.FavoriteGames)
                {
                    sb.Append(favoriteGame.name);
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
                    Console.WriteLine($"Game: {userReview.reviewedGame.name} Rating: {userReview.rating}");
                    Console.WriteLine($"Review content: {userReview.content}");
                    Console.WriteLine("---------------");
                }
            }
            Console.WriteLine("==============================================================");
        }
        public void displayGame(Game game)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine($"Id: {game.id}");
                Console.WriteLine($"Name: {game.name}");
                Console.WriteLine($"Release date: {game.releaseDate.ToLongDateString()}");
                Console.WriteLine($"Rating: {game.calculateTotalRating()}");
                Console.WriteLine($"Game details: {game.gameDetails}");

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
                                Console.WriteLine($"Reply from {reply.replyOwner.username}: {reply.content}");
                            }
                        }
                    }
                }
                Console.WriteLine("==============================================================");
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void displayMenu()
        {
            Console.WriteLine("Welcome. Please enter your command: ");
            Console.WriteLine("1. Display all games");
            Console.WriteLine("2. Display all users");
            Console.WriteLine("3. Display game by id");
        }

        public void displayAllGames(List<Game> gamelist)
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
                    displayGame(game);
                }
            }
            catch (GameException ex)
            {
                Console.WriteLine(ex.Message);
            }
            #if DEBUG
            finally
            {
                Debug.Write("function executed");
                Console.WriteLine("Function display all games executed");
            }
            #endif
        }

        public void displayAllUsers(List<User> users)
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
                    displayUser(user);
                }
            }
            catch(UserException ex)
            {
                Console.WriteLine(ex.Message);
            }
            #if DEBUG
            finally
            {
                Debug.Write("function executed");
                Console.WriteLine("Function display all users executed");
            }
            #endif
        }
    }
}
