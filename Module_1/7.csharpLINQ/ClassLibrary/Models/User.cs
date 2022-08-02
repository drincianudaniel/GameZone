﻿using System;
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

        public void PostReview(Game gameToBeReviewed, double rating, string content)
        {
            Review review = new Review(this, gameToBeReviewed, rating, content);
            gameToBeReviewed.Reviews.Add(review);
            gameToBeReviewed.CalculateTotalRating();
            userReviews.Add(review);
        }
        public void AddGameToFavorite(Game favoriteGame)
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
                var commentToReply = gameToBeReplied.Comments.Where(comment => comment.id == commentToReplyID).FirstOrDefault();
                commentToReply.replies.Add(new Reply(this, commentToReply, content));
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
                var commentToDelete = gameToDeleteComment.Comments.Where(comment => comment.id == id).FirstOrDefault();
                gameToDeleteComment.Comments.Remove(commentToDelete);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException($"Comment with id: {id} does not exist.");
            }
        }
    }
}
