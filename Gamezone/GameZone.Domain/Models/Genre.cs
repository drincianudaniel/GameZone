using GameZone.Domain.Models;

namespace GameZone.Domain.Models
{
    public class Genre : AuditableEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Game> Games { get; set; } 
    }
}

