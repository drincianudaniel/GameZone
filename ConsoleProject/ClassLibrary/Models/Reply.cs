using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels
{
    public class Reply
    {
        public int id { get; set; }
        public string Content { get; set; }
        public User ReplyOwner { get; set; }
        public Comment Comment { get; set; }
        public Reply(User replyOwner, Comment comment, string content)
        {
            this.ReplyOwner = replyOwner;
            this.Comment = comment;
            this.Content = content;
        }
    }
}
