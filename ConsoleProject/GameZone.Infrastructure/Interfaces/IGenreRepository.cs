using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Interfaces
{
    internal interface IGenreRepository
    {
        void Create(Genre Genre);
        void Delete(int id);
        List<Genre> ReturnAll();
        Genre ReturnById(int id);
    }
}
