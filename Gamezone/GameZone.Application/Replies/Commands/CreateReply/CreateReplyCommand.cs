using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Replies.Commands.CreateReply
{
    public class CreateReplyCommand : IRequest<Reply>
    {
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }
        public string Content { get; set; }
    }
}
