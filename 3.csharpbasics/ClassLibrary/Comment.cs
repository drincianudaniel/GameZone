using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Comment
    {
        public int id { get; set; }
        public User commentOwer { get; set; }
        public string content { get; set; }

        public Comment(User commentOwner, string content)
        {
            this.commentOwer = commentOwner;
            this.content = content;
        }
    }
}
