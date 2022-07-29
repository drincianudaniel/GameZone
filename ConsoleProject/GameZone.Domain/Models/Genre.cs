using GameZone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels
{
    public class Genre : Entity
    {
        private static int serial = 1;
        public string Name { get; set; }
        public Genre(string name)
        {
            this.Name = name;
            this.Id = serial++;
        }
    }
}

