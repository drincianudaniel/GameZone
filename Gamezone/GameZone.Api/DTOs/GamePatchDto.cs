using System.ComponentModel.DataAnnotations;

namespace GameZone.Api.DTOs
{
    public class GamePatchDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [UrlAttribute]
        public string ImageSrc { get; set; }
        [Required]
        [MaxLength(1000), MinLength(20)]
        public string GameDetails { get; set; }
    }
}
