using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Genre : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Game> Games { get; set; } 
    }
}

