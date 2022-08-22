using GameZone.Domain.Models;

namespace GameZone.Domain.Models
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Reply> Replies { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public string Role { get; set; }
    }
}
