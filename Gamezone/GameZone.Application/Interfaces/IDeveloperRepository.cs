using GameZoneModels;

namespace GameZone.Application
{
    public interface IDeveloperRepository
    {
        void Create(Developer Developer);
        void Delete(Guid id);
        IEnumerable<Developer> ReturnAll();
        Developer ReturnById(Guid id);
        void Update(Developer developer);
    }
}
