using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Replies.Commands.DeleteReply
{
    public class DeleteReplyCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
