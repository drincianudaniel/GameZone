using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Developer : Entity
    {
        public string Name { get; set; }

        // TODO: maybe Headquarters can be an object
        public string Headquarters { get; set; }

        // TODO: why virtual
        // public virtual ICollection<Game> Games { get; set; }
        public ICollection<GameDeveloper> Games { get; set; }
    }
}
