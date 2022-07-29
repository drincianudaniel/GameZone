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
        public List<Developer> Games { get; set; }

        public DeveloperRepository()
        {
            Games = new List<Developer>();
        }

        public void CreateGame(Developer Developer)
        {
            Games.Add(Developer);
        }

        public Developer ReturnGameById(int id)
        {
            try
            {
                var developerToReturn = Games.Where(developer => developer.Id == id).FirstOrDefault();
                return developerToReturn;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException($"Developer with id {id} doesn't exist.");
            }
        }
    }
}