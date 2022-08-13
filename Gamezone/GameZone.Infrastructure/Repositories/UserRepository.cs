using GameZone.Application;
using GameZoneModels;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GameZoneContext _context;
        public UserRepository(GameZoneContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> ReturnByIdAsync(Guid id)
        {
            var userToReturn = await _context.Users
                .Where(user => user.Id == id)
                .Include(x => x.Games)
                .Include(x => x.Comments).ThenInclude(x => x.Game)
                .Include(x => x.Replies)
                .Include(x => x.Reviews).ThenInclude(x => x.Game)
                .FirstOrDefaultAsync();
            if (userToReturn == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return userToReturn;
        }

        public async Task<IEnumerable<User>> ReturnAllAsync()
        {
            return await _context.Users
                .Include(x => x.Games)
                .Include(x => x.Comments).ThenInclude(x => x.Game)
                .Include(x => x.Replies)
                .Include(x => x.Reviews).ThenInclude(x=> x.Game)
                .ToListAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task AddGameToFavorite(User user, Game favoriteGame)
        {
            user.Games.Add(favoriteGame);
            await _context.SaveChangesAsync();
        }

        /*public void PostComment(Game gameToBeCommented, Comment comment)
        {
            gameToBeCommented.Comments.Add(comment);
        }

        public void PostReply(Comment comment, Reply reply)
        {
            comment.Replies.Add(reply);
        }

        public void PostReview(Game gameToBeReviewd, Review review)
        {
            gameToBeReviewd.Reviews.Add(review);
        }

        public void DeleteComment(User userToDeleteComment, Game game, Comment comment)
        {
            if (userToDeleteComment.Role == "Admin")
            {
                game.Comments.Remove(comment);
            }
            else
            {
                throw new UnauthorizedAccessException("User not authorized");
            }
        }

       */
    }
}
