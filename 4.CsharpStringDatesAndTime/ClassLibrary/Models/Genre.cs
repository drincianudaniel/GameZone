﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZoneModels
{
    public class Genre
    {
        private static int serial = 1;
        public int id { get; set; }
        public string name { get; set; }

        public Genre(string name)
        {
            this.name = name;
            this.id = serial++;
        }
    }
}

