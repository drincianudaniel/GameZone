using GameZone.Application;
using GameZoneModels;

namespace GameZone.Infrastructure.Repositories
{
    public class InMemoryPlatformRepository : IPlatformRepository
    {
        private readonly List<Platform> _platforms;
        public InMemoryPlatformRepository()
        {
            _platforms = new List<Platform>
            {
                new("Pc"),
                new("Xbox One"),
                new("PlayStation 4"),
                new("PlayStation 5")
            };
        }

        public void Create(Platform platform)
        {
            _platforms.Add(platform);
        }

        public Platform ReturnById(int id)
        {
            var platformToReturn = _platforms.Find(platform => platform.Id == id);
            if (platformToReturn == null)
            {
                throw new KeyNotFoundException("Platform not found");
            }
            return platformToReturn;
        }
        public IEnumerable<Platform> ReturnAll()
        {
            if (_platforms.Count() == 0)
            {
                throw new NullReferenceException("Platforms list is null");
            }
            return _platforms;
        }
        public void Update(int id, Platform platform)
        {
            var platformToEdit = ReturnById(id);
            platformToEdit.Name = platformToEdit.Name;
        }
        public void Delete(int id)
        {
            var platformToBeDeleted = ReturnById(id);
            _platforms.Remove(platformToBeDeleted);
        }
    }
}
