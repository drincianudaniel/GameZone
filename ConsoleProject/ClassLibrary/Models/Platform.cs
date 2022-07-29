using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels
{
    public class Platform
    {
        private static int serial = 1;
        public int id { get; set; }
        public string Name { get; set; }

        public Platform(string name)
        {
            this.Name = name;
            this.id = serial++;
        }
    }
}
