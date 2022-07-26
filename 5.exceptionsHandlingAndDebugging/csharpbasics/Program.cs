using GameZone.Domain.Display;
using GameZone.Domain.Exceptions;
using GameZoneModels;
using System;

namespace GameZone.ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //AllGames
                List<Game> allGames = new List<Game>();
                List<Game> emptyList = new List<Game>();
                //AllUsers
                List<User> allUsers = new List<User>();
                //users
                User user1 = new User("regularuser1@gmail.com", "regularuser123123", "password", "Regular", "User");
                User user2 = new User("regularuser2@gmail.com", "regularuser2", "password", "Another Regular", "User");
                User admin1 = new User("admin@gmail.com", "adminuser", "password", "Admin User", "Admin");
                allUsers.Add(user1);
                allUsers.Add(user2);
                allUsers.Add(admin1);
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

                allGames.Add(AssassinsCreed);
                allGames.Add(lol);
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
                //consoleDisplay.displayRegularUserInfo(user1);
                //consoleDisplay.displayRegularUserInfo(user2);
                //display games
                //consoleDisplay.displayGame(AssassinsCreed);
                //consoleDisplay.displayGame(lol);

                //Game.returnGameById(allGames, 1231230);
                //consoleDisplay.displayGame(returnedGame);

                bool repeat = false;
                char input;
                do
                {
                    consoleDisplay.displayMenu();
                    string s = Console.ReadLine();
                    int n = Int32.Parse(s);
                    switch (n)
                    {
                        case 1:
                            consoleDisplay.displayAllGames(emptyList);
                            break;
                        case 2:
                            consoleDisplay.displayAllUsers(allUsers);
                            break;
                        case 3:
                            Console.WriteLine("Enter id: ");
                            consoleDisplay.displayGame(Game.returnGameById(allGames, int.Parse(Console.ReadLine().ToString())));                   
                            break;
                        default:
                            Console.WriteLine("Invalid selection");
                            break;
                    }
                    Console.WriteLine("Would you like to repeat? Y/N");
                    input = Convert.ToChar(Console.ReadLine());
                    repeat = (input == 'Y');
                } while (input == 'y') ;
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}