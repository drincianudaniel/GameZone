using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Developer
    {
        private static int serial = 1;
        public int id { get; set; }
        public string name { get; set; }

        public Developer(string name)
        {
            this.name = name;
            this.id = serial++;
        }
    }
}
