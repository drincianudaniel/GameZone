using System.ComponentModel.DataAnnotations;
namespace GameZone.Api.ViewModels
{
    public class ReplyViewModel
    {
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
