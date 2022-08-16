using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.DTOs
{
    public class SimpleGameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageSrc { get; set; } = string.Empty;
        public double TotalRating { get; set; }
    }
}
