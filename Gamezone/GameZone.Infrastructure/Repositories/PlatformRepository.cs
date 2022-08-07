using GameZone.Application;
using GameZone.Domain;
using GameZoneModels;

namespace GameZone.Infrastructure.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly GameZoneContext _context;
        public PlatformRepository(GameZoneContext context)
        {
            _context = context;
        }

        public void Create(Platform platform)
        {
            _context.Platforms.Add(platform);
            _context.SaveChanges();
        }

        public Platform ReturnById(Guid id)
        {
            var platformToReturn = _context.Platforms.Where(p => p.Id == id).FirstOrDefault();
            if (platformToReturn == null)
            {
                throw new KeyNotFoundException("Platform not found");
            }
            return platformToReturn;
        }
        public IEnumerable<Platform> ReturnAll()
        {
            return _context.Platforms;
        }
        public void Update(Platform platform)
        {
            var platformAux = _context.Platforms.Where(platform => platform.Id == platform.Id).FirstOrDefault();
            if (platformAux == null)
            {
                throw new NullReferenceException("Platform doesnt exist");
            }
            _context.Platforms.Remove(platformAux);
            _context.Platforms.Add(platform);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var platformToBeDeleted = ReturnById(id);
            _context.Platforms.Remove(platformToBeDeleted);
            _context.SaveChanges();
        }
    }
}
