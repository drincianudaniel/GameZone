namespace GameZone.Api.DTOs
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public string UserProfileImage { get; set; }
        public string UserName { get; set; }
        public string Gamename { get; set; }
        public Guid GameId { get; set; }
        public double Rating { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
