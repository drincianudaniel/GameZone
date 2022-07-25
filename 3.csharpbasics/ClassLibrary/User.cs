using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class User
    {
        private static int serial = 1; 
        public int id { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }

        public User()
        {
            this.id = serial++;
        }
        public void Login()
        {
            Console.WriteLine("User logged in");
        }

        public void Logout()
        {
            Console.WriteLine("User logged out");
        }

        public void postComment(Game gameToBeCommented, string content)
        {
            gameToBeCommented.Comments.Add(new Comment(this, content));
        }

        public void replyToComment(Game gameToBeReplied,int commentToReplyID, string content)
        {
            //find commentById
            var commentToReply = gameToBeReplied.Comments.Where(comment => comment.id == commentToReplyID).FirstOrDefault();
            /* foreach (var comment in commentToReply)
             {
                 comment.replies.Add(new Reply(this, comment, content));
             }*/
            if(commentToReply != null)
            {
                commentToReply.replies.Add(new Reply(this, commentToReply, content));
            }
        }
    }
}
