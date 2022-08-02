using GameZone.Infrastructure.Interfaces;
using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private List<Platform> Platforms { get; set; }
        public PlatformRepository()
        {
            Platforms = new List<Platform>();
        }

        public void Create(Platform platform)
        {
            Platforms.Add(platform);
        }

        public Platform ReturnById(int id)
        {
            var platformToReturn = Platforms.Find(platform => platform.Id == id);
            if (platformToReturn == null)
            {
                throw new KeyNotFoundException("Platform not found");
            }
            return platformToReturn;
        }
        public List<Platform> ReturnAll()
        {
            if (Platforms.Count() == 0)
            {
                throw new NullReferenceException("Platforms list is null");
            }
            return Platforms;
        }
        public void Update(int id, Platform platform)
        {
            var platformToEdit = ReturnById(id);
            platformToEdit.Name = platformToEdit.Name;
        }
        public void Delete(int id)
        {
            var platformToBeDeleted = ReturnById(id);
            Platforms.Remove(platformToBeDeleted);
        }
    }
}
