namespace GameZone.Api.ViewModels
{
    public class ReviewViewModel
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public double Rating { get; set; }
        public string Content { get; set; }
    }
}
