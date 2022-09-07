using GameZone.Domain.Models;

namespace GameZone.Domain.Models
{
    public class Reply : AuditableEntity
    {
        public string Content { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public Guid? CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
