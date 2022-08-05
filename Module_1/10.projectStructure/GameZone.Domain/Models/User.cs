using GameZone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels
{
    public class User : Entity
    {
        private static int serial = 1;
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Game> FavoriteGames { get; set; }
        public ICollection<Review> userReviews { get; set; }
        public string Role { get; set; }

        public User(string email, string username, string password, string firstName, string lastName, string role, ICollection<Game> favoriteGames)
        {
            this.Email = email;
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
            FavoriteGames = favoriteGames ?? throw new ArgumentNullException(nameof(favoriteGames));
            userReviews = new List<Review>();
            this.Id = serial++;
        }
    }
}
