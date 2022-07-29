using GameZone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels
{
    public class Review : Entity
    {
        private static int serial = 1;
        public User Reviewer { get; set; }
        public Game ReviewedGame { get; set; }
        public double Rating { get; set; }
        public string? Content { get; set; }
        public Review(User reviewer, Game reviewedGame, double rating, string content)
        {
            this.Reviewer = reviewer;
            this.ReviewedGame = reviewedGame;
            this.Rating = rating;
            this.Content = content;
            this.Id = serial++;
        }
    }
}
