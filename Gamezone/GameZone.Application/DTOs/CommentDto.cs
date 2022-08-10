﻿using GameZoneModels;

namespace GameZone.Application.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Game Game { get; set; }
        public string Content { get; set; }
        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}