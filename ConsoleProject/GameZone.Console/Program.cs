﻿using GameZone.Domain.Display;
using GameZone.Domain.Exceptions;
using GameZoneModels;
using System;
using GameZone.Infrastructure.Repositories;

namespace GameZone.ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //consoledisplay 
                ConsoleDisplay consoleDisplay = new ConsoleDisplay();
                //users repo
                var userRepo = new UserRepository();
                userRepo.Create(new User("user@gmail.com", "User", "qweasdzxc", "User", "1"));
                //developers repo
                var developerRepo = new DeveloperRepository();
                developerRepo.Create(new Developer("Ubisoft"));
                developerRepo.Create(new Developer("Riot Games"));
                var ubisoft = developerRepo.ReturnById(1);
                var riotGames = developerRepo.ReturnById(2);
                //genres repo
                var genreRepo = new GenreRepository();
                genreRepo.Create(new Genre("Action"));
                genreRepo.Create(new Genre("Adventure"));
                //platform repo
                var platformRepo = new PlatformRepository();
                platformRepo.Create(new Platform("PlayStation4"));
                platformRepo.Create(new Platform("Pc"));
                //games repo
                var gameRepo = new GameRepository();
                gameRepo.Create(new Game("Assassins Creed", new DateTime(2007, 11, 13), "Assassin's Creed is an open-world action-adventure stealth video game franchise published by Ubisoft and developed mainly by its studio Ubisoft Montreal using the game engine Anvil and its more advanced derivatives. Created by Patrice Désilets, Jade Raymond, and Corey May, the Assassin's Creed series depicts a fictional millennia-old struggle between the Assassins, who fight for peace and free will, and the Templars, who desire peace through order and control. "));
                gameRepo.AddDeveloper(1, ubisoft);
                gameRepo.Create(new Game("League of Legends", new DateTime(2009, 10, 27), "League of Legends, commonly referred to as League, is a 2009 multiplayer online battle arena video game developed and published by Riot Games. Inspired by Defense of the Ancients, a custom map for Warcraft III, Riot's founders sought to develop a stand-alone game in the same genre."));
                gameRepo.AddDeveloper(2, riotGames);
                //comments

                var commentsRepo = new CommentRepository();
                
                commentsRepo.Create(new Comment(userRepo.ReturnById(1), "bun joc"));
                var AssassinsCreed = gameRepo.ReturnById(1);
                AssassinsCreed.Comments.Add(commentsRepo.ReturnById(1));



                /*  Game lol = new Game("League of Legends", new DateTime(2009, 10, 27), "League of Legends, commonly referred to as League, is a 2009 multiplayer online battle arena video game developed and published by Riot Games. Inspired by Defense of the Ancients, a custom map for Warcraft III, Riot's founders sought to develop a stand-alone game in the same genre.");

                  lol.Developers = new List<Developer> { RiotGames };
                  lol.Genres = new List<Genre> { Adventure };
                  lol.Platforms = new List<Platform> { pc };
                  lol.Reviews = new List<Review>();
                  lol.Comments = new List<Comment>();*/

                /*allGames.Add(AssassinsCreed);
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
                user1.AddGameToFavorite(lol);*/

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
                            consoleDisplay.DisplayAllGames(gameRepo.ReturnAll());
                            break;
                        case 2:
                            consoleDisplay.DisplayAllUsers(userRepo.ReturnAll());
                            break;
                        case 3:
                            Console.Write("Enter id: ");
                            consoleDisplay.DisplayGame(gameRepo.ReturnById(int.Parse(Console.ReadLine().ToString())));                   
                            break;
                        case 4:
                            Console.WriteLine("Enter game name: ");
                            string gameName = Console.ReadLine();
                            Console.WriteLine("Enter year: ");
                            int year = int.Parse(Console.ReadLine().ToString());
                            Console.WriteLine("Enter month: ");
                            int month = int.Parse(Console.ReadLine().ToString());
                            Console.WriteLine("Enter day: ");
                            int day = int.Parse(Console.ReadLine().ToString());
                            Console.WriteLine("Enter game details: ");
                            string gameDetails = Console.ReadLine();
                            var createdGame = new Game(gameName, new DateTime(year, month, day), gameDetails);
                            gameRepo.Create(createdGame);
                            break;
                        case 5:
                            do
                            {
                                var loggedInUser = userRepo.ReturnById(1);
                                consoleDisplay.DisplayAllGames(gameRepo.ReturnAll());
                                Console.WriteLine("Choose a game from the list to manage: ");
                                int gameId = int.Parse(Console.ReadLine().ToString());
                                var game = gameRepo.ReturnById(gameId);
                                Console.WriteLine($"The choosen game is {game.Name}");
                                consoleDisplay.DisplayGameMenu();
                                Console.Write("Choose an option: ");
                                s = Console.ReadLine();
                                n = Int32.Parse(s);
                                switch (n)
                                {
                                    case 1:
                                        consoleDisplay.DisplayDevelopers(developerRepo.ReturnAll());
                                        Console.WriteLine("Choose a developer to add: ");
                                        int developerId = int.Parse(Console.ReadLine().ToString());
                                        var developerToAdd = developerRepo.ReturnById(developerId);
                                        gameRepo.AddDeveloper(gameId, developerToAdd);
                                        break;
                                    case 2:
                                        consoleDisplay.DisplayGenres(genreRepo.ReturnAll());
                                        Console.WriteLine("Choose a Genre to add: ");
                                        int genreId = int.Parse(Console.ReadLine().ToString());
                                        var genreToAdd = genreRepo.ReturnById(genreId);
                                        gameRepo.AddGenre(gameId, genreToAdd);
                                        break;
                                    case 3:
                                        consoleDisplay.DisplayPlatforms(platformRepo.ReturnAll());
                                        Console.WriteLine("Choose a Platform to add: ");
                                        int platformId = int.Parse(Console.ReadLine().ToString());
                                        var platformToAdd = platformRepo.ReturnById(platformId);
                                        gameRepo.AddPlatform(gameId, platformToAdd);
                                        break;
                                    case 4:
                                        Console.WriteLine("Post a comment: ");
                                        string comment = Console.ReadLine();
                                        userRepo.PostComment(game, new Comment(loggedInUser, comment));
                                        break;
                                    default:
                                        Console.WriteLine("Invalid selection");
                                        break;
                                }
                                Console.WriteLine("Would you like to repeat? Y/N");
                                input = Convert.ToChar(Console.ReadLine());
                            } while (input == 'Y' || input == 'y');
                            break;
                        case 6:
                            consoleDisplay.DisplayAllGames(gameRepo.GenerateTopList());
                            break;
                        default:
                            Console.WriteLine("Invalid selection");
                            break;
                    }
                    Console.WriteLine("Would you like to repeat? Y/N");
                    input = Convert.ToChar(Console.ReadLine());
                    repeat = (input == 'Y' || input == 'y');
                } while (input == 'Y' || input == 'y');
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (DuplicateWaitObjectException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}