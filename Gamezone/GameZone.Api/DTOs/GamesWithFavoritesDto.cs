namespace GameZone.Api.DTOs
{
    public class GamesWithFavoritesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageSrc { get; set; } = string.Empty;
        public bool IsFavorite { get; set; }

    }
}
