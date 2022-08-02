using GameZone.Infrastructure.Interfaces;
using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private List<Developer> Developers { get; set; }

        public DeveloperRepository()
        {
            Developers = new List<Developer>();
        }

        public void Create(Developer Developer)
        {
            Developers.Add(Developer);
        }

        public Developer ReturnById(int id)
        {
            var developerToReturn = Developers.Find(developer => developer.Id == id);
            if (developerToReturn == null)
            {
                throw new KeyNotFoundException("Developer not found");
            }
            return developerToReturn;
        }
        public List<Developer> ReturnAll()
        {
            if (Developers.Count() == 0)
            {
                throw new NullReferenceException("Developers list is null");
            }
            return Developers;
        }
        public void Update(int id, Developer developer)
        {
            var developerToEdit = ReturnById(id);
            developerToEdit.Name = developer.Name;
        }
        public void Delete(int id)
        {
            var developerToBeDeleted = ReturnById(id);
            Developers.Remove(developerToBeDeleted);
        }
    }
}