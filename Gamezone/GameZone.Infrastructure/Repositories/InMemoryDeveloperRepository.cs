﻿using GameZone.Application;
using GameZoneModels;

namespace GameZone.Infrastructure.Repositories
{
    public class InMemoryDeveloperRepository : IDeveloperRepository
    {
        private readonly List<Developer> _developers;

        public InMemoryDeveloperRepository()
        {
           /* _developers = new List<Developer>
            {
                new("Ubisoft", "Montreul, France"),
                new("Riot Games", "West Los Angeles, California, United States"),
                new("CD PROJEKT RED", "Warsaw, Poland")
            };*/
        }

        public void Create(Developer Developer)
        {
            _developers.Add(Developer);
        }

        public Developer ReturnById(Guid id)
        {
            var developerToReturn = _developers.Find(developer => developer.Id == id);
            if (developerToReturn == null)
            {
                throw new KeyNotFoundException("Developer not found");
            }
            return developerToReturn;
        }
        public IEnumerable<Developer> ReturnAll()
        {
            if (_developers.Count() == 0)
            {
                throw new NullReferenceException("Developers list is null");
            }
            return _developers;
        }
        public void Update(Guid id, Developer developer)
        {
            var developerToEdit = ReturnById(id);
            developerToEdit.Name = developer.Name;
        }
        public void Delete(Guid id)
        {
            var developerToBeDeleted = ReturnById(id);
            _developers.Remove(developerToBeDeleted);
        }
    }
}