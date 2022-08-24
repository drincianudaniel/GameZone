using System.ComponentModel.DataAnnotations;
namespace GameZone.Api.ViewModels
{
    public class GameViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [UrlAttribute]
        public string ImageSrc { get; set; }
        [Required]
        public string GameDetails { get; set; }
        public List<Guid> DeveloperList { get; set; } = new List<Guid>();
        public List<Guid> GenreList { get; set; } = new List<Guid>();
        public List<Guid> PlatformList { get; set; } = new List<Guid>();
    }
}
