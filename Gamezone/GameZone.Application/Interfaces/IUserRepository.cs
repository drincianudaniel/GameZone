using GameZoneModels;

namespace GameZone.Application
{
    public interface IUserRepository
    {
        void AddGameToFavorite(User user, Game favoriteGame);
        void Create(User user);
        void Delete(Guid id);
        void DeleteComment(User userToDeleteComment, Game game, Comment comment);
        void PostReply(Comment comment, Reply reply);
        void PostReview(Game gameToBeReviewd, Review review);
        IEnumerable<User> ReturnAll();
        User ReturnById(Guid id);
        void Update(Guid id, User user);
    }
}
