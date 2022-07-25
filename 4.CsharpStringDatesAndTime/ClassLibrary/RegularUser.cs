using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class RegularUser : User
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public List<Game> FavoriteGames { get; set; }
        public List<Review> userReviews { get; set; }

        public RegularUser(string email, string username, string password, string firstName, string lastName)
        {
            this.email = email;
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            FavoriteGames = new List<Game>();
            userReviews = new List<Review>();
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
    }
}
