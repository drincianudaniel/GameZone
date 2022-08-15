using GameZone.Application.DTOs;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<CommentDto>
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public string Content { get; set; }
    }
}
