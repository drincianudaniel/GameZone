using GameZoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.DTOs
{
    public class ReplyDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
    }
}
