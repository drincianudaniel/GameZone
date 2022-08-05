using GameZoneModels;

namespace GameZone.Application
{
    public interface IPlatformRepository
    {
        void Create(Platform platform);
        void Delete(int id);
        IEnumerable<Platform> ReturnAll();
        Platform ReturnById(int id);
        void Update(int id, Platform platform);
    }
}
