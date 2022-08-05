using GameZoneModels;

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
