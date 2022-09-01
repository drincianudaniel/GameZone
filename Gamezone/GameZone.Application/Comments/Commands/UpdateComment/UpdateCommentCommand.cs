using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand: IRequest<Comment>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public string Content { get; set; }
    }
}
