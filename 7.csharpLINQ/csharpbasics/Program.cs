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
                List<Developer> DevelopersList = new List<Developer>{ Ubisoft, RiotGames};

                //genres
                Genre Action = new Genre("Action");
                Genre Adventure = new Genre("Adventure");
                Genre Simulation = new Genre("Simulation");
                List<Genre> GenresList = new List<Genre> { Action, Adventure };

                //platform
                Platform ps4 = new Platform("PlayStation 4");
                Platform pc = new Platform("Pc");
                List<Platform> PlatformList = new List<Platform> { ps4, pc };

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
                user1.PostReview(AssassinsCreed, 8.5, "good game");
                user1.PostReview(lol, 4, "bad game");
                user2.PostReview(AssassinsCreed, 7.5, "ok game");

                //comments
                user1.PostComment(AssassinsCreed, "i liked it");
                admin1.PostComment(AssassinsCreed, "i liked it too");
                user2.PostComment(lol, "toxic game");
                admin1.DeleteComment(AssassinsCreed, 1);

                //replies
                user2.ReplyToComment(AssassinsCreed, 2, "yes good game");
                user1.ReplyToComment(lol, 3, "game is good");

                //favoritegames
                user1.AddGameToFavorite(AssassinsCreed);
                user1.AddGameToFavorite(lol);

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
                    consoleDisplay.DisplayMenu();
                    Console.Write("Choose an options: ");
                    string s = Console.ReadLine();
                    int n = Int32.Parse(s);
                    switch (n)
                    {
                        case 1:
                            consoleDisplay.DisplayAllGames(allGames);
                            break;
                        case 2:
                            consoleDisplay.DisplayAllUsers(allUsers);
                            break;
                        case 3:
                            Console.Write("Enter id: ");
                            consoleDisplay.DisplayGame(Game.ReturnGameById(allGames, int.Parse(Console.ReadLine().ToString())));                   
                            break;
                        case 4:
                            //hard coded for now
                            Game newGame = admin1.CreateGame("naruto", 2000, 10, 2, "NarutoGame");
                            allGames.Add(newGame);
                            break;
                        case 5:                      
                            do
                            {
                                consoleDisplay.DisplayAllGames(allGames);
                                Console.WriteLine("Choose a game from the list to manage: ");
                                int gameId = int.Parse(Console.ReadLine().ToString());
                                var game = Game.ReturnGameById(allGames, gameId);
                                Console.WriteLine($"The choosen game is {game.name}");
                                consoleDisplay.DisplayGameMenu();
                                Console.Write("Choose an option: ");
                                s = Console.ReadLine();
                                n = Int32.Parse(s);
                                switch (n)
                                {
                                    case 1:
                                        consoleDisplay.DisplayDevelopers(DevelopersList);
                                        Console.WriteLine("Choose a developer: ");
                                        int developerId = int.Parse(Console.ReadLine().ToString());
                                        game.AddDeveloperToGameByID(DevelopersList, developerId);
                                        break;
                                    case 2:
                                        consoleDisplay.DisplayGenres(GenresList);
                                        Console.WriteLine("Choose a Genre: ");
                                        int genreId = int.Parse(Console.ReadLine().ToString());
                                        game.AddGenreToGameByID(GenresList, genreId);
                                        break;
                                    case 3:
                                        consoleDisplay.DisplayPlatforms(PlatformList);
                                        break;
                                    case 4:
                                        break;
                                    default:
                                        Console.WriteLine("Invalid selection");
                                        break;
                                }
                                Console.WriteLine("Would you like to repeat? Y/N");
                                input = Convert.ToChar(Console.ReadLine());
                            } while (input == 'Y' || input == 'y');
                            Console.WriteLine("Press any key to exit.");
                            Console.ReadKey();
                            break;
                        case 6:
                            consoleDisplay.DisplayAllGames(Game.GenerateTopList(allGames));
                            break;
                        default:
                            Console.WriteLine("Invalid selection");
                            break;
                    }
                    Console.WriteLine("Would you like to repeat? Y/N");
                    input = Convert.ToChar(Console.ReadLine());
                    repeat = (input == 'Y' || input == 'y');
                } while (input == 'Y' || input == 'y') ;
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