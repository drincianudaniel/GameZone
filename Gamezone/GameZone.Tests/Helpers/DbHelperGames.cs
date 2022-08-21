using GameZone.Application.DTOs;
using GameZoneModels;
using System;
using System.Collections.Generic;

namespace GameZone.Tests.Helpers
{
    public static class DbHelperGames
    {
        public static List<GameViewModel> GetTestGames()
        {
            var games = new List<GameViewModel>();
            games.Add(new GameViewModel()
            {
                Name = "Test 1",
                ReleaseDate = DateTime.Now,
                GameDetails = "details",
                ImageSrc = "test.jpg"
            });

            return games;
        }
    }
}
