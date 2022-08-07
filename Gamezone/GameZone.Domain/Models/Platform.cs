using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Platform : Entity
    {
        public string Name { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
