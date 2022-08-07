using GameZoneModels;

namespace GameZone.Application
{
    public interface IPlatformRepository
    {
        void Create(Platform platform);
        void Delete(Guid id);
        IEnumerable<Platform> ReturnAll();
        Platform ReturnById(Guid id);
        void Update(Platform platform);
    }
}
