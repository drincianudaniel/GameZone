using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application
{
    public interface IGenreRepository
    {
        void Create(Genre Genre);
        void Delete(int id);
        IEnumerable<Genre> ReturnAll();
        Genre ReturnById(int id);
        void Update(int id, Genre genre);
    }
}
