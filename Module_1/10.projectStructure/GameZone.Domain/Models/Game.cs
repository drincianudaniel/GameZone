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
        public ICollection<Developer> Developers { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Platform> Platforms { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Game(string name, DateTime releaseDate, string gameDetails, List<Developer> developers, List<Genre> genres, List<Platform> platforms)
        {
            this.Name = name;
            this.ReleaseDate = releaseDate;
            this.GameDetails = gameDetails;
            this.Id = serial++;
            Developers = developers ?? throw new ArgumentNullException(nameof(developers));
            Genres = genres ?? throw new ArgumentNullException(nameof(genres));
            Platforms = platforms ?? throw new ArgumentNullException(nameof(platforms));
            Reviews = new List<Review>();
            Comments = new List<Comment>();
        }
        
        public void AddDeveloper(Developer developer)
        {
            Developers.Add(developer);
        }

        public void AddGenre(Genre genre)
        {
            Genres.Add(genre);
        }

        public void AddPlatform(Platform platform)
        {
            Platforms.Add(platform);
        }
    }
}
