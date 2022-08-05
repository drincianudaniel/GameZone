using GameZone.Domain.Display;
using GameZoneModels;
using System;

namespace GameZone.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //users
            User user1 = new User("regularuser1@gmail.com", "regularuser123123", "password", "Regular", "User");
            User user2 = new User("regularuser2@gmail.com", "regularuser2", "password", "Another Regular", "User");
            User admin1 = new User("admin@gmail.com", "adminuser", "password", "Admin User", "Admin");
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

            //replies
            user2.replyToComment(AssassinsCreed, 2, "yes good game");
            user1.replyToComment(lol, 3, "game is good");

            //favoritegames
            user1.addGameToFavorite(AssassinsCreed);
            user1.addGameToFavorite(lol);

            //display
            ConsoleDisplay consoleDisplay = new ConsoleDisplay();
            //display user info
            consoleDisplay.displayRegularUserInfo(user1);
            consoleDisplay.displayRegularUserInfo(user2);
            //display games
            consoleDisplay.displayGame(AssassinsCreed);
            consoleDisplay.displayGame(lol);
        }
    }
}