using System.ComponentModel.DataAnnotations;

namespace GameZone.Api.ViewModels
{
    public class CommentPutViewModel
    {
        [Required]
        [MaxLength(500), MinLength(20)]
        public string Content { get; set; }
    }
}
