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

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User ReturnById(Guid id)
        {
            var userToReturn = _context.Users.Include("Games").Where(user => user.Id == id).FirstOrDefault();
            if (userToReturn == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return userToReturn;
        }

        public IEnumerable<User> ReturnAll()
        {
            return _context.Users.Include("Games");
        }

        public void Update(User user)
        {
            var userAux = _context.Users.Where(user => user.Id == user.Id).FirstOrDefault();
            if (userAux == null)
            {
                throw new NullReferenceException("User doesnt exist");
            }
            _context.Users.Remove(userAux);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var userToBeRemoved = ReturnById(id);
            _context.Users.Remove(userToBeRemoved);
            _context.SaveChanges();
        }

        public void PostComment(Game gameToBeCommented, Comment comment)
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

        public void AddGameToFavorite(User user, Game favoriteGame)
        {
            user.Games.Add(favoriteGame);
        }
    }
}
