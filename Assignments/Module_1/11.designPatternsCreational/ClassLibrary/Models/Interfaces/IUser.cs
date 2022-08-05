using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Domain.Models.Interfaces
{
    public interface IUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Game> FavoriteGames { get; set; }
        public List<Review> userReviews { get; set; }

        void AddGameToFavorite(Game favoriteGame);
        void DeleteComment(Game gameToDeleteComment, int id);
        void PostComment(Game gameToBeCommented, string content);
        void PostReview(Game gameToBeReviewed, double rating, string content);
        void ReplyToComment(Game gameToBeReplied, int commentToReplyID, string content);
    }
}
