using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Review : Entity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public double Rating { get; set; }
        public string Content { get; set; }
    }
}
