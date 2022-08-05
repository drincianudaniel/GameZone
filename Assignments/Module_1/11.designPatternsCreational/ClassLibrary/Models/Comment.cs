using GameZone.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels
{
    public class Comment
    {
        private static int serial = 1;
        public int id { get; set; }
        public IUser commentOwer { get; set; }
        public string content { get; set; }
        public List<Reply> replies { get; set; }
        public Comment(IUser commentOwner, string content)
        {
            this.commentOwer = commentOwner;
            this.content = content;
            this.id = serial++;
            replies = new List<Reply>();
        }
    }
}
