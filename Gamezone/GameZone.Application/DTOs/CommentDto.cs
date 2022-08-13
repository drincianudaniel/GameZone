﻿using GameZoneModels;

namespace GameZone.Application.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Gamename { get; set; }
        public string Content { get; set; }
        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}
