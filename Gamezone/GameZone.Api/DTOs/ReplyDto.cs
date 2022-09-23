﻿namespace GameZone.Api.DTOs
{
    public class ReplyDto
    {
        public Guid Id { get; set; }
        public string UserProfileImage { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
