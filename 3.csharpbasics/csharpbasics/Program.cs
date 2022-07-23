using ClassLibrary;
using System;

namespace csharpbasics
{
    class Program
    {
        public static void displayRegularUserInfo(RegularUser user)
        {
            Console.WriteLine("Id: " + user.id);
            Console.WriteLine("Email: " + user.email);
            Console.WriteLine("Username: " + user.username);
            Console.WriteLine("Name: " + user.firstName + " " + user.lastName);
            if (user.FavoriteGames.Count > 0)
            {
                Console.WriteLine("Favorite Games: ");
                foreach (var i in user.FavoriteGames)
                {
                    Console.Write(i.name + " ");
                }
            }
            Console.WriteLine("");
            if (user.userReviews.Count > 0)
            {
                Console.WriteLine("User Reviews: ");
                foreach (var i in user.userReviews)
                {
                    Console.WriteLine(i.reviewedGame.name);
                    Console.WriteLine(i.content + " ");
                    Console.WriteLine("---------------");
                }
            }
            Console.WriteLine("==============================================================");
        }
        public static void displayGame(Game game)
        {
            Console.WriteLine("Id: " + game.id);
            Console.WriteLine("Name: " + game.name);
            Console.WriteLine("Release date: " + game.releaseDate);
            Console.WriteLine("Rating: " + game.calculateTotalRating());
            Console.WriteLine("Game details: " + game.gameDetails);

            Console.Write("Developers: ");
            foreach (var i in game.Developers)
            {
                Console.Write(i.name + " ");
            }

            Console.WriteLine(" ");
            Console.Write("Genres: ");
            foreach (var i in game.Genres)
            {
                Console.Write(i.name + " ");
            }

            Console.WriteLine(" ");
            Console.Write("Platforms: ");
            foreach (var i in game.Platforms)
            {
                Console.Write(i.name + " ");
            }
            Console.WriteLine(" ");
            
            if (game.Reviews.Count > 0)
            {
                Console.WriteLine("Reviews: ");
                foreach (var i in game.Reviews)
                {
                    Console.Write(i.reviewer.lastName + " " + i.reviewer.firstName + ": ");
                    Console.Write(i.rating + " ");
                    Console.WriteLine(i.content);
                }
            }

            if (game.Comments.Count > 0)
            {
                Console.WriteLine("Comments: ");
                foreach (var i in game.Comments)
                {
                    Console.Write(i.commentOwer.username + ": ");
                    Console.WriteLine(i.content);
                }
            }
            Console.WriteLine("==============================================================");
        }
        static void Main(string[] args)
        {

            //users
            RegularUser user1 = new RegularUser("regularuser1@gmail.com", "regularuser123123", "password", "Regular", "User");
            RegularUser user2 = new RegularUser("regularuser2@gmail.com", "regularuser2", "password", "Another Regular", "User");
            Admin admin1 = new Admin("adminName", "admin1@gmail.com", "admin1231123", "password");
            //game developers
            Developer Ubisoft = new Developer("Ubisoft");
            Developer RiotGames = new Developer("Riot Games");

            //genres
            Genre Action = new Genre("Action");
            Genre Adventure = new Genre("Adventure");

            //platform
            Platform ps4 = new Platform("PlayStation 4");
            Platform pc = new Platform("Pc");

            //games
            Game AssassinsCreed = new Game("Assassins Creed", new DateTime(2007, 11, 13), "Assassin's Creed is an open-world action-adventure stealth video game franchise published by Ubisoft and developed mainly by its studio Ubisoft Montreal using the game engine Anvil and its more advanced derivatives. Created by Patrice Désilets, Jade Raymond, and Corey May, the Assassin's Creed series depicts a fictional millennia-old struggle between the Assassins, who fight for peace and free will, and the Templars, who desire peace through order and control. ");
            
            AssassinsCreed.Developers = new List<Developer> { Ubisoft };
            AssassinsCreed.Genres = new List<Genre> { Action, Adventure };
            AssassinsCreed.Platforms = new List<Platform> { ps4 };
            AssassinsCreed.Reviews = new List<Review>();
            AssassinsCreed.Comments = new List<Comment>();


            Game lol = new Game("League of Legends", new DateTime(2009, 10, 27), "League of Legends, commonly referred to as League, is a 2009 multiplayer online battle arena video game developed and published by Riot Games. Inspired by Defense of the Ancients, a custom map for Warcraft III, Riot's founders sought to develop a stand-alone game in the same genre.");

            lol.Developers = new List<Developer> { RiotGames };
            lol.Genres = new List<Genre> { Adventure };
            lol.Platforms = new List<Platform> { pc };
            lol.Reviews = new List<Review>();
            lol.Comments = new List<Comment>();
            //reviews
            user1.postReview(AssassinsCreed, 8.5, "good game");
            user1.postReview(lol, 4, "bad game");
            user2.postReview(AssassinsCreed, 7.5, "ok game");

            //comments
            user1.postComment(AssassinsCreed, "i liked it");
            admin1.postComment(AssassinsCreed, "i liked it too");
            user2.postComment(lol, "toxic game");
            admin1.deleteComment(AssassinsCreed, 1);


            //favoritegames
            user1.addGameToFavorite(AssassinsCreed);
            user1.addGameToFavorite(lol);
            //display games
            displayGame(AssassinsCreed);
            displayGame(lol);

            //display user info
            displayRegularUserInfo(user1);
            displayRegularUserInfo(user2);
        }
    }
}