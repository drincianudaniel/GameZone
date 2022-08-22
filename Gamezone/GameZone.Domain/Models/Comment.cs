using GameZone.Domain.Models;

// TODO should be namespace GameZone.Domain.Models
namespace GameZoneModels
{
    public class Comment : Entity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public string Content { get; set; }

        public ICollection<Reply> Replies { get; set; }
    }
}
