using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.DTOs
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Gamename { get; set; }
        public double Rating { get; set; }
        public string Content { get; set; }
    }
}
