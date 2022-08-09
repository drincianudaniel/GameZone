using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Replies.Commands.DeleteReply
{
    public class DeleteReplyCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
