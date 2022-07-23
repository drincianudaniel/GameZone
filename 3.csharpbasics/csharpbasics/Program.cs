using ClassLibrary;
using System;

namespace csharpbasics
{
    class Program
    {
        public static void showGame(Game game)
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
            Console.WriteLine("----------------------------");
        }
        static void Main(string[] args)
        {

            //users
            RegularUser user1 = new RegularUser("regularuser1@gmail.com", "regularuser", "Regular", "User");
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
            Game AssassinsCreed = new Game("Assassins Creed", new DateTime(2015, 12, 25), "Assassin's Creed is an open-world action-adventure stealth video game franchise published by Ubisoft and developed mainly by its studio Ubisoft Montreal using the game engine Anvil and its more advanced derivatives. Created by Patrice Désilets, Jade Raymond, and Corey May, the Assassin's Creed series depicts a fictional millennia-old struggle between the Assassins, who fight for peace and free will, and the Templars, who desire peace through order and control. ");
            
            AssassinsCreed.Developers = new List<Developer> { Ubisoft };
            AssassinsCreed.Genres = new List<Genre> { Action, Adventure };
            AssassinsCreed.Platforms = new List<Platform> { ps4 };
            AssassinsCreed.Reviews = new List<Review>();


            Game lol = new Game("League of Legends", new DateTime(2014, 12, 23), "Toxic");

            lol.Developers = new List<Developer> { RiotGames };
            lol.Genres = new List<Genre> { Adventure };
            lol.Platforms = new List<Platform> { pc };
            lol.Reviews = new List<Review>();

            //reviews
            user1.postReview(AssassinsCreed, 8.5, "good game");

            showGame(AssassinsCreed);
            showGame(lol);
        }
    }
}