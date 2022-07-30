using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Interfaces
{
    internal interface IDeveloperRepository
    {
        void Create(Developer Developer);
        Developer ReturnById(int id);
    }
}
