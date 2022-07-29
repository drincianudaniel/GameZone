using GameZone.Domain.Exceptions;
using GameZone.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels 
{
    public class Game : Entity
    {
        private static int serial = 1;
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double TotalRating { get; set; }
        public string GameDetails { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Platform> Platforms { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Comment> Comments { get; set; }
        public Game(string name, DateTime releaseDate, string gameDetails)
        {
            this.Name = name;
            this.ReleaseDate = releaseDate;
            this.GameDetails = gameDetails;
            this.Id = serial++;
            Developers = new List<Developer>();
            Genres = new List<Genre>();
            Platforms = new List<Platform>();
            Reviews = new List<Review>();
            Comments = new List<Comment>();
        }  
    }
}
