using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Review : Entity
    {
        public User User { get; set; }
        public Game Game { get; set; }
        public double Rating { get; set; }
        public string? Content { get; set; }
    }
}
