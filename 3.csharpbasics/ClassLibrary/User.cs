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
    }
}
