using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Developer
    {
        public int id { get; set; }
        public string name { get; set; }

        public Developer(string name)
        {
            this.name = name;
        }
    }
}
