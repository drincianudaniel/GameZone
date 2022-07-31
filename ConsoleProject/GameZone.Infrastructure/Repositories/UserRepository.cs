using GameZone.Infrastructure.Interfaces;
using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> Users { get; set; }
        public UserRepository()
        {
            Users = new List<User>();
        }

        public void Create(User user)
        {
            Users.Add(user);
        }

        public User ReturnById(int id)
        {
            var userToReturn = Users.Find(user => user.Id == id);
            if (userToReturn == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return userToReturn;
        }

        public List<User> ReturnAll()
        {
            return Users;
        }

        public void Delete(int id)
        {
            var userToBeRemoved = ReturnById(id);
            Users.Remove(userToBeRemoved);
        }

        public void PostComment(Game gameToBeCommented, Comment comment)
        {
            gameToBeCommented.Comments.Add(comment);
        }

      /*  public void PostReview(Game gameToBeReviewed, double rating, string content)
        {
            Review review = new Review(this, gameToBeReviewed, rating, content);
            gameToBeReviewed.Reviews.Add(review);
            //gameToBeReviewed.CalculateTotalRating();
            userReviews.Add(review);
        }*/
      /*  public void AddGameToFavorite(Game favoriteGame)
        {
            FavoriteGames.Add(favoriteGame);
        }
        public void PostComment(Game gameToBeCommented, string content)
        {
            gameToBeCommented.Comments.Add(new Comment(this, content));
        }
        public void ReplyToComment(Game gameToBeReplied, int commentToReplyID, string content)
        {
            //find commentById 
            try
            {
                var commentToReply = gameToBeReplied.Comments.Where(comment => comment.Id == commentToReplyID).FirstOrDefault();
                commentToReply.Replies.Add(new Reply(this, commentToReply, content));
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException($"Comment with id: {commentToReplyID} does not exist.");
            }
        }
        public void DeleteComment(Game gameToDeleteComment, int id)
        {
            try
            {
                var commentToDelete = gameToDeleteComment.Comments.Where(comment => comment.Id == id).FirstOrDefault();
                gameToDeleteComment.Comments.Remove(commentToDelete);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException($"Comment with id: {id} does not exist.");
            }
        }*/
    }
}
