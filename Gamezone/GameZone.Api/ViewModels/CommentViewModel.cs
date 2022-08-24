using System.ComponentModel.DataAnnotations;
namespace GameZone.Api.ViewModels
{
    public class CommentViewModel
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
