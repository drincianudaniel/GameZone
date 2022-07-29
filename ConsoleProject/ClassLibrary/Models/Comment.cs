using GameZone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels
{
    public class Comment : Entity
    {
        private static int serial = 1;
        public User CommentOwer { get; set; }
        public string Content { get; set; }
        public List<Reply> Replies { get; set; }
        public Comment(User commentOwner, string content)
        {
            this.CommentOwer = commentOwner;
            this.Content = content;
            this.Id = serial++;
            Replies = new List<Reply>();
        }
    }
}
