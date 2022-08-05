using GameZoneModels;

namespace GameZone.Application
{
    public interface IUserRepository
    {
        void AddGameToFavorite(User user, Game favoriteGame);
        void Create(User user);
        void Delete(int id);
        void DeleteComment(User userToDeleteComment, Game game, Comment comment);
        void PostReply(Comment comment, Reply reply);
        void PostReview(Game gameToBeReviewd, Review review);
        IEnumerable<User> ReturnAll();
        User ReturnById(int id);
        void Update(int id, User user);
    }
}
