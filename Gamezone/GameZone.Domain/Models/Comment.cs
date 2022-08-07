using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Comment : Entity
    {
        public User User { get; set; }
        public string Content { get; set; }
        public ICollection<Reply> Replies { get; set; }
    }
}
