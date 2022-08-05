using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels 
{
    public class Game
    {
        private static int serial = 1;
        public int id { get; set; }
        public string name { get; set; }
        public DateTime releaseDate { get; set; }
        public double totalRating { get; set; }
        public string gameDetails { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Platform> Platforms { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Comment> Comments { get; set; }
        public Game(string name, DateTime releaseDate, string gameDetails)
        {
            this.name = name;
            this.releaseDate = releaseDate;
            this.gameDetails = gameDetails;
            this.id = serial++;
        }

        public double calculateTotalRating()
        {
            foreach (var i in Reviews)
            {
                this.totalRating += i.rating;
            }
            return this.totalRating / Reviews.Count();
        }
    }
}
