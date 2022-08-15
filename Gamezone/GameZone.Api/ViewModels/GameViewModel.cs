namespace GameZone.Api.ViewModels
{
    public class GameViewModel
    {
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string ImageSrc { get; set; } = string.Empty;
        public string GameDetails { get; set; } = string.Empty;
        public List<Guid> DeveloperList { get; set; } = new List<Guid>();
        public List<Guid> GenreList { get; set; } = new List<Guid>();
        public List<Guid> PlatformList { get; set; } = new List<Guid>();
    }
}
