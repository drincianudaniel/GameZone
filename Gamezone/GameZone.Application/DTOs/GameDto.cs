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
        public ICollection<Developer> Developers { get; set; } = new List<Developer>();
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public ICollection<Platform> Platforms { get; set; } = new List<Platform>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
