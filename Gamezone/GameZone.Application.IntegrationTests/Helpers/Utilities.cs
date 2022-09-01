﻿using GameZone.Domain.Models;
using GameZone.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.IntegrationTests.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(GameZoneContext db)
        {
            var genre1 = new Genre { Name = "Action" };
            var genre2 = new Genre { Name = "Adventure" };
            var genre3 = new Genre { Name = "Horror" };

            db.Genres.AddRange(genre1, genre2, genre3);
            db.SaveChanges();
        }
    }
}
