namespace GameZone.Api.DTOs
{
    public class GameWithFavoriteDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageSrc { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string GameDetails { get; set; } = string.Empty;
        public double TotalRating { get; set; }
        public ICollection<DeveloperDto> Developers { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
        public ICollection<PlatformDto> Platforms { get; set; }
        public ReviewDto Review { get; set; }
        public bool IsFavorite { get; set; }
    }
}
