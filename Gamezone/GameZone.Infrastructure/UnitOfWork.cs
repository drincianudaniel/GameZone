using GameZone.Application;
using GameZone.Application.Interfaces;

namespace GameZone.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameZoneContext _gameZoneContext;
        public ICommentRepository CommentRepository { get; private set; }
        public IDeveloperRepository DeveloperRepository { get; private set; }
        public IGameRepository GameRepository { get; private set; }
        public IGenreRepository GenreRepository { get; private set; }
        public IPlatformRepository PlatformRepository { get; private set; }
        public IReplyRepository ReplyRepository { get; private set; }
        public IReviewRepository ReviewRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public UnitOfWork(
            GameZoneContext gameZoneContext,
            ICommentRepository commentRepository,
            IDeveloperRepository developerRepository,
            IGameRepository gameRepository,
            IGenreRepository genreRepository,
            IPlatformRepository platformRepository,
            IReplyRepository replyRepository,
            IReviewRepository reviewRepository,
            IUserRepository userRepository)
        {
            _gameZoneContext = gameZoneContext;
            CommentRepository=commentRepository;
            DeveloperRepository=developerRepository;
            GameRepository=gameRepository;
            GenreRepository=genreRepository;
            PlatformRepository=platformRepository;
            ReplyRepository=replyRepository;
            ReviewRepository=reviewRepository;
            UserRepository=userRepository;
        }

        public async Task SaveAsync()
        {
            await _gameZoneContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _gameZoneContext.Dispose();
        }

       
    }
}
