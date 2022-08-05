using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Comment : Entity
    {
        private static int serial = 1;
        public User CommentOwer { get; set; }
        public string Content { get; set; }
        public ICollection<Reply> Replies { get; set; }
        public Comment(User commentOwner, string content)
        {
            this.CommentOwer = commentOwner;
            this.Content = content;
            this.Id = serial++;
            Replies = new List<Reply>();
        }
    }
}
