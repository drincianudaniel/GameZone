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
        void Create(Game game);
        void Delete(int id);
        List<Game> ReturnAll();
        Game ReturnById(int id);
    }
}
