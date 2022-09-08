using System.ComponentModel.DataAnnotations;
namespace GameZone.Api.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid GameId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}
