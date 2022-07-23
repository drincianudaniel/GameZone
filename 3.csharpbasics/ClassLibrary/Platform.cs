using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Platform
    {
        private static int serial = 1;
        public int id { get; set; }
        public string name { get; set; }

        public Platform(string name)
        {
            this.name = name;
            this.id = serial++;
        }
    }
}
