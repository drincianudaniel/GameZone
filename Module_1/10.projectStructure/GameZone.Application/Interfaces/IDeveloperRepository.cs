using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application
{
    public interface IDeveloperRepository
    {
        void Create(Developer Developer);
        void Delete(int id);
        IEnumerable<Developer> ReturnAll();
        Developer ReturnById(int id);
        void Update(int id, Developer developer);
    }
}
