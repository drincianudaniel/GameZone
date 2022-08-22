using GameZone.Domain.Models;

namespace GameZone.Domain.Models
{
    public class Genre : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Game> Games { get; set; } 
    }
}

