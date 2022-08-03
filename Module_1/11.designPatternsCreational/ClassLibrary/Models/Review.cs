using GameZone.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels
{
    public class Review
    {
        private static int serial = 1;
        public int id { get; set; }
        public IUser reviewer { get; set; }
        public Game reviewedGame { get; set; }
        public double rating { get; set; }
        public string? content { get; set; }
        public Review(IUser reviewer, Game reviewedGame, double rating, string content)
        {
            this.reviewer = reviewer;
            this.reviewedGame = reviewedGame;
            this.rating = rating;
            this.content = content;
            this.id = serial++;
        }
    }
}
