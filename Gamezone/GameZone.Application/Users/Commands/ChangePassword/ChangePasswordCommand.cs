﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Users.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<bool>
    {
        public string UserId { get; set; } 
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
