﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }

        public Genre(string name)
        {
            this.name = name;
        }
    }
}

