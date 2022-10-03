using GameZone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Dtos
{
    public class UserWithRolesDto
    {
        public User User { get; set; }
        public List<string> Roles { get; set; }
    }
}
