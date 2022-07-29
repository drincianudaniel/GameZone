using GameZone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels
{
    public class Developer : Entity
    {
        private static int serial = 1;
        public string Name { get; set; }
        public Developer(string name)
        {
            this.Name = name;
            this.Id = serial++;
        }
    }
}
