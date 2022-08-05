﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Reply
    {
        public int id { get; set; }
        public string content { get; set; }
        public User replyOwner { get; set; }
        public Comment comment { get; set; }
        public Reply(User replyOwner, Comment comment, string content)
        {
            this.replyOwner = replyOwner;
            this.comment = comment;
            this.content = content;
        }
    }
}
