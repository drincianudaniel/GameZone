namespace GameZone.Api.DTOs
{
    public class SimpleGameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageSrc { get; set; } = string.Empty;
        public double TotalRating { get; set; }
    }
}
