using GameZone.Application;
using GameZoneModels;

namespace GameZone.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> Users;
        public InMemoryUserRepository()
        {
            Users = new List<User>
            {
                /*new("admin@gmail.com", "Admin", "qweasdzxc", "Admin", "one", "Admin", new List<Game>()),
                new("user@gmail.com", "User", "qweasdzxc", "User", "one", "User", new List<Game>())*/
            };
        }

        public void Create(User user)
        {
            Users.Add(user);
        }

        public User ReturnById(Guid id)
        {
            var userToReturn = Users.Find(user => user.Id == id);
            if (userToReturn == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return userToReturn;
        }

        public IEnumerable<User> ReturnAll()
        {
            if (Users.Count() == 0)
            {
                throw new NullReferenceException("Users list is null");
            }
            return Users;
        }

        public void Update(Guid id, User user)
        {
            var userToUpdate = ReturnById(id);
            userToUpdate.Email = user.Email;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Password = user.Password;
            userToUpdate.Username = user.Username;
        }

        public void Delete(Guid id)
        {
            var userToBeRemoved = ReturnById(id);
            Users.Remove(userToBeRemoved);
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
