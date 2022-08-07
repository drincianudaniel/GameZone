using GameZoneModels;

namespace GameZone.Application
{
    public interface IGenreRepository
    {
        void Create(Genre Genre);
        void Delete(Guid id);
        IEnumerable<Genre> ReturnAll();
        Genre ReturnById(Guid id);
        void Update(Genre genre);
    }
}
