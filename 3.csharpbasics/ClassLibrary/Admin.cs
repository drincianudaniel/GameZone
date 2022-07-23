using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Admin : User
    {
        public string adminName { get; set; }

        public Admin(string adminName, string email, string username, string password)
        {
            this.adminName = adminName;
            this.email = email;
            this.username = username;
            this.password = password;
        }
    }
  
}
