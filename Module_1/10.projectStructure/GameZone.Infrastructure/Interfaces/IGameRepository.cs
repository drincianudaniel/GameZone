using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Interfaces
{
    internal interface IGameRepository
    {
        void AddDeveloper(int gameId, Developer developer);
        void AddGenre(int gameId, Genre genre);
        void AddPlatform(int gameId, Platform platform);
        void CalculateTotalRating(Game game);
        void Create(Game game);
        void Delete(int id);
        List<Game> GenerateTopList();
        List<Game> ReturnAll();
        Game ReturnById(int id);
        void Update(int id, Game game);
    }
}
