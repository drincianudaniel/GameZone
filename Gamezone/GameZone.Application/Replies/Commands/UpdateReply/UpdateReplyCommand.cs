using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Replies.Commands.UpdateReply
{
    public class UpdateReplyCommand : IRequest<Reply>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }
        public string Content { get; set; }
    }
}
