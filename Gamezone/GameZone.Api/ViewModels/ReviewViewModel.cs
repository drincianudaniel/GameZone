using System.ComponentModel.DataAnnotations;
namespace GameZone.Api.ViewModels
{
    public class ReviewViewModel
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        [Required]
        [Range(1, 10)]
        public double Rating { get; set; }
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}
