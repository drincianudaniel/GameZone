using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Comment>
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
