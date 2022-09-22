using Microsoft.AspNetCore.Identity;

namespace GameZone.Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageSrc { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Reply> Replies { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
