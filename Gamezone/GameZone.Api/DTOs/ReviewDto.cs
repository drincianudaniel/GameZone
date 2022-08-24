namespace GameZone.Api.DTOs
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Gamename { get; set; }
        public double Rating { get; set; }
        public string Content { get; set; }
    }
}
