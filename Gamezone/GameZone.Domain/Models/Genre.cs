using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Genre : Entity
    {
        public string Name { get; set; }
        public ICollection<Game> Games { get; set; } 
    }
}

