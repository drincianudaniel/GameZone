namespace GameZone.Api.ViewModels
{
    public class CommentViewModel
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public string Content { get; set; }
    }
}
