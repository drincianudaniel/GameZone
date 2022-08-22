﻿using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Reply : Entity
    {
        public string Content { get; set; }

        // TODO: object nullable?
        public Guid? UserId { get; set; }
        public User User { get; set; }

        public Guid? CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
