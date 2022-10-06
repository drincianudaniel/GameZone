using GameZone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Dtos
{
    public class GameWithUserFavoriteDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageSrc { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string GameDetails { get; set; } = string.Empty;
        public double TotalRating { get; set; }
        public ICollection<Developer> Developers { get; set; }
        public ICollection<Genre> Genres { get; set; } 
        public ICollection<Platform> Platforms { get; set; }
        public bool IsFavorite { get; set; }
        public Review Review { get; set; }
    }
}
