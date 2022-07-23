using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Review
    {
        public int id { get; set; }
        public RegularUser reviewer { get; set; }
        public double rating { get; set; }
        public string? content { get; set; }
        public Review(RegularUser reviewer, double rating, string content)
        {
            this.reviewer = reviewer;
            this.rating = rating;
            this.content = content;
        }
    }
}
