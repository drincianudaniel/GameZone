using GameZone.Domain.Models.Interfaces;
using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Domain.Models
{
    public class RegularUser : IUser
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public List<Game> FavoriteGames { get; set; }
        public List<Review> userReviews { get; set; }
    }
}
