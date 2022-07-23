﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Admin : User
    {
        private IEnumerable<Comment> commentToBeDeleted;

        public string adminName { get; set; }

        public Admin(string adminName, string email, string username, string password)
        {
            this.adminName = adminName;
            this.email = email;
            this.username = username;
            this.password = password;
        }

        public void deleteComment(Game gameToDeleteComment, int id)
        {
            /*gameToDeleteComment.Comments.Remove((Comment)gameToDeleteComment.Comments.Where(comment => comment.id ==  id));*/
            var commentToDelete = gameToDeleteComment.Comments.Where(comment => comment.id == 1).ToList();
            foreach(var comment in commentToDelete)
            {
                gameToDeleteComment.Comments.Remove(comment);
            }
        }
    }
  
}
