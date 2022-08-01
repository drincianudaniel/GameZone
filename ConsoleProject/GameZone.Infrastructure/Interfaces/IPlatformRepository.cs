using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Interfaces
{
    internal interface IPlatformRepository
    {
        void Create(Platform platform);
        void Delete(int id);
        List<Platform> ReturnAll();
        Platform ReturnById(int id);
        void Update(int id, Platform platform);
    }
}
