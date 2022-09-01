using GameZone.Domain.Models;
using GameZone.Infrastructure;
using System;

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
            var platform2 = new Platform { Name = "PC" };
            var platform3 = new Platform { Name = "Xbox One" };

            db.Platforms.AddRange(platform1, platform2, platform3);

            var developer1 = new Developer { Id = new Guid("e830d6d6-ff42-4a25-a933-ef5fe62945ed"), Name = "Ubisoft", Headquarters= "Montreal" };
            var developer2 = new Developer { Name = "Mojang", Headquarters= "Stockholm" };
            var developer3 = new Developer { Name = "Riot Games", Headquarters= "West Los Angeles" };

            db.Developers.AddRange(developer1, developer2, developer3);
            db.SaveChanges();
        }
    }
}
