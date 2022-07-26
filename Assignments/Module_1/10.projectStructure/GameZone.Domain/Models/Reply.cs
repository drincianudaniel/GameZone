﻿using GameZone.Domain.Models;

namespace GameZoneModels
{
    public class Reply : Entity
    {
        private static int serial = 1;
        public string Content { get; set; }
        public User ReplyOwner { get; set; }
        public Comment Comment { get; set; }
        public Reply(User replyOwner, Comment comment, string content)
        {
            this.ReplyOwner = replyOwner;
            this.Comment = comment;
            this.Content = content;
            this.Id = serial++;
        }
    }
}
