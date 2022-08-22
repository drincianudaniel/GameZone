using GameZoneModels;

namespace GameZone.Domain.Models
{
    public class GameDeveloper
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public Guid DeveloperId { get; set; }
        public Developer Developer { get; set; }
    }
}
