using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels
{
    public class User
    {
        private static int serial = 1; 
        public int id { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public List<Game> FavoriteGames { get; set; }
        public List<Review> userReviews { get; set; }

        public User(string email, string username, string password, string firstName, string lastName)
        {
            this.id = serial++;
            this.email = email;
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            FavoriteGames = new List<Game>();
            userReviews = new List<Review>();
        }
        public void Login()
        {
            Console.WriteLine("User logged in");
        }

        public void Logout()
        {
            Console.WriteLine("User logged out");
        }

        public void postReview(Game gameToBeReviewed, double rating, string content)
        {
            Review review = new Review(this, gameToBeReviewed, rating, content);
            gameToBeReviewed.Reviews.Add(review);
            userReviews.Add(review);
        }
        public void addGameToFavorite(Game favoriteGame)
        {
            FavoriteGames.Add(favoriteGame);
        }
        public void postComment(Game gameToBeCommented, string content)
        {
            gameToBeCommented.Comments.Add(new Comment(this, content));
        }
        public void replyToComment(Game gameToBeReplied,int commentToReplyID, string content)
        {
            //find commentById
            var commentToReply = gameToBeReplied.Comments.Where(comment => comment.id == commentToReplyID).FirstOrDefault();
            if(commentToReply != null)
            {
                commentToReply.replies.Add(new Reply(this, commentToReply, content));
            }
        }
        public void deleteComment(Game gameToDeleteComment, int id)
        {
            var commentToDelete = gameToDeleteComment.Comments.Where(comment => comment.id == id).FirstOrDefault();
            if (commentToDelete != null)
            {
                gameToDeleteComment.Comments.Remove(commentToDelete);
            }

        }
    }
}
