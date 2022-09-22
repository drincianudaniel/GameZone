using GameZone.Domain.Models;
using GameZone.Infrastructure;
using System;
using System.Collections.Generic;

namespace GameZone.IntegrationTests.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(GameZoneContext db)
        {
            var genre1 = new Genre { Id = new Guid("611da6e3-9b9e-43c4-a539-3758cf69f330"), Name = "Action" };
            var genre2 = new Genre { Name = "Adventure" };
            var genre3 = new Genre { Name = "Horror" };

            db.Genres.AddRange(genre1, genre2, genre3);

            var platform1 = new Platform { Id = new Guid("c0dc1fdf-9615-4cf6-834a-3c36a28b4798"), Name = "PlayStation 4" };
            var platform2 = new Platform { Id = new Guid("964a6257-1a9e-4f9b-bb54-9c4ca4582c65"), Name = "PC" };
            var platform3 = new Platform { Id = new Guid("b35d0bce-ba18-4f14-aa7b-69f4fddbc535"), Name = "Xbox One" };

            db.Platforms.AddRange(platform1, platform2, platform3);

            var developer1 = new Developer { Id = new Guid("e830d6d6-ff42-4a25-a933-ef5fe62945ed"), Name = "Ubisoft", Headquarters= "Montreal" };
            var developer2 = new Developer { Name = "Mojang", Headquarters= "Stockholm" };
            var developer3 = new Developer { Name = "Riot Games", Headquarters= "West Los Angeles" };
            var developer4 = new Developer { Id = new Guid("f019d75b-9945-44a9-80d5-0da4a8b3e75e"), Name = "Rockstar Games", Headquarters = "New York" };
            db.Developers.AddRange(developer1, developer2, developer3, developer4);

            var minecraft = new Game
            {
                Id = new Guid("2df905bf-8205-4466-942d-713a689431c1"),
                Name = "Minecraft",
                ReleaseDate = new DateTime(2011, 11, 18),
                GameDetails = "Minecraft is a sandbox video game developed by Mojang Studios. The game was created by Markus Notch Persson in the Java programming language.",
                ImageSrc = "https://upload.wikimedia.org/wikipedia/en/5/51/Minecraft_cover.png",
                Genres = new List<Genre> { genre2 },
                Developers = new List<Developer> { developer2 },
                Platforms = new List<Platform> { platform2, platform3 },
            };

            var valorant = new Game
            {
                Id = new Guid("e936442f-ac01-4b7f-935c-52b99d5be660"),
                Name = "Valorant",
                ReleaseDate = new DateTime(2020, 6, 2),
                GameDetails = "Valorant is a free-to-play first-person hero shooter developed and published by Riot Games, for Microsoft Windows. First teased under the codename Project A in October 2019, the game began a closed beta period with limited access on April 7, 2020, followed by an official release on June 2, 2020.",
                ImageSrc = "https://img.republicworld.com/republic-prod/stories/promolarge/xhdpi/jy2kkydqjduwcdee_1594886538.jpeg",
                Genres = new List<Genre> { genre1 },
                Developers = new List<Developer> { developer3 },
                Platforms = new List<Platform> { platform2 },
            };

            db.Games.AddRange(minecraft, valorant);
            var user = new User
            {
                Id = new Guid("f535d0fc-020c-4549-8dce-6496ceedcd22"),
                UserName = "UserName",
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "username@gmail.com",
            };

            db.Users.Add(user);

            var comment = new Comment
            {
                Id = new Guid("94842162-2252-43b2-9c2a-807a86a4393b"),
                Content = "very good game",
                UserId = user.Id,
                GameId = minecraft.Id
            };

            db.Comments.Add(comment);

            var review = new Review
            {
                Id = new Guid("ba2104c7-0106-4e36-bd50-5f44e672e447"),
                Content = "one of the best game i ever played",
                Rating = 10,
                UserId = user.Id,
                GameId = minecraft.Id
            };

            db.Reviews.Add(review);

            var reply = new Reply
            {
                Id = new Guid("c41a1c51-a15e-4346-9ad6-cdc2cd017274"),
                Content = "reply to comment",
                UserId = user.Id,
                CommentId = comment.Id
            };

            db.Replies.Add(reply);

            db.SaveChanges();
        }
    }
}
