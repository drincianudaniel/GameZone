namespace GameZone.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICommentRepository CommentRepository { get; }
        public IDeveloperRepository DeveloperRepository { get; }
        public IGameRepository GameRepository { get; }
        public IGenreRepository GenreRepository { get; }
        public IPlatformRepository PlatformRepository { get; }
        public IReplyRepository ReplyRepository { get; }
        public IReviewRepository ReviewRepository { get; }
        public IUserRepository UserRepository { get; }
        Task SaveAsync();
    }
}
