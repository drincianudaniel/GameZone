using GameZoneModels;

namespace GameZone.Application
{
    public interface IUserRepository
    {
        Task AddGameToFavorite(User user, Game favoriteGame);
        Task CreateAsync(User user);
        Task DeleteAsync(User user);
        /* void DeleteComment(User userToDeleteComment, Game game, Comment comment);
         void PostReply(Comment comment, Reply reply);
         void PostReview(Game gameToBeReviewd, Review review);*/
        Task<IEnumerable<User>> ReturnAllAsync();
        Task<User> ReturnByIdAsync(Guid id);
        Task UpdateAsync(User user);
    }
}
