﻿using GameZone.Application.DTOs;
using GameZoneModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public string Content { get; set; }
    }
}
