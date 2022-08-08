﻿using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Game : Entity
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double TotalRating { get; set; }
        public string GameDetails { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Developer> Developers { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Platform> Platforms { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Comment> Comments { get; set; }
        
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
