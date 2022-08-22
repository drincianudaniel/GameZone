using GameZone.Domain.Models;

namespace GameZone.Domain.Models
{
    public class Platform : Entity
    {
        public string Name { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
