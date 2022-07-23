using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class RegularUser : User
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }

        public RegularUser(string email, string password, string firstName, string lastName)
        {
            this.email = email;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public void postReview(Game gameToBeReviewd, double rating, string content)
        {
            gameToBeReviewd.Reviews.Add(new Review(this.firstName + " " + this.lastName, rating, content));
        }
    }
}
