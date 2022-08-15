using GameZone.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace GameZoneModels
{
    public class Review : Entity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }

        [Range(1, 10)]
        public double Rating { get; set; }
        public string Content { get; set; }
    }
}
