using GameZoneModels;


namespace GameZone.Application.DTOs
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string GameDetails { get; set; } = string.Empty;
        public double TotalRating { get; set; }
        public ICollection<DeveloperDto> Developers { get; set; } = new List<DeveloperDto>();
        public ICollection<GenreDto> Genres { get; set; } = new List<GenreDto>();
        public ICollection<PlatformDto> Platforms { get; set; } = new List<PlatformDto>();
        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public ICollection<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    }
}
