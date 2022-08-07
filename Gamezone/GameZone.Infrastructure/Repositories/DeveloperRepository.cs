using GameZone.Application;
using GameZone.Domain;
using GameZoneModels;

namespace GameZone.Infrastructure.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly GameZoneContext _context;

        public DeveloperRepository(GameZoneContext context)
        {
            _context = context;
        }

        public void Create(Developer Developer)
        {
            _context.Developers.Add(Developer);
            _context.SaveChanges();
        }

        public Developer ReturnById(Guid id)
        {
            var developerToReturn = _context.Developers.Where(developer => developer.Id == id).FirstOrDefault();
            if (developerToReturn == null)
            {
                throw new KeyNotFoundException("Developer not found");
            }
            return developerToReturn;
        }
        public IEnumerable<Developer> ReturnAll()
        {
            return _context.Developers;
        }
        public void Update(Developer developer)
        {
            var developerAux = _context.Developers.Where(developer => developer.Id == developer.Id).FirstOrDefault();
            if (developerAux == null)
            {
                throw new NullReferenceException("Developer doesnt exist");
            }
            _context.Developers.Remove(developerAux);
            _context.Developers.Add(developer);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var developerToBeDeleted = ReturnById(id);
            _context.Developers.Remove(developerToBeDeleted);
            _context.SaveChanges();
        }
    }
}