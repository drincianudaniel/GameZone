﻿using GameZone.Domain.Models;

namespace GameZone.Domain.Models
{
    public class Comment : AuditableEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public string Content { get; set; }
        public ICollection<Reply> Replies { get; set; }
    }
}
