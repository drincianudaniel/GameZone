using GameZone.Infrastructure.Interfaces;
using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Repositories
{
    public class InMemoryDeveloperRepository : IDeveloperRepository
    {
        private readonly List<Developer> _developers;

        public InMemoryDeveloperRepository()
        {
            _developers = new List<Developer>
            {
                new("Ubisoft"),
                new("Riot Games"),
                new("CD PROJEKT RED")
            };
        }

        public void Create(Developer Developer)
        {
            _developers.Add(Developer);
        }

        public Developer ReturnById(int id)
        {
            var developerToReturn = _developers.Find(developer => developer.Id == id);
            if (developerToReturn == null)
            {
                throw new KeyNotFoundException("Developer not found");
            }
            return developerToReturn;
        }
        public List<Developer> ReturnAll()
        {
            if (_developers.Count() == 0)
            {
                throw new NullReferenceException("Developers list is null");
            }
            return _developers;
        }
        public void Update(int id, Developer developer)
        {
            var developerToEdit = ReturnById(id);
            developerToEdit.Name = developer.Name;
        }
        public void Delete(int id)
        {
            var developerToBeDeleted = ReturnById(id);
            _developers.Remove(developerToBeDeleted);
        }
    }
}