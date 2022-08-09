using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Comments.Queries.GetCommentById
{
    public class GetCommentByIdQuery : IRequest<CommentDto>
    {
        public Guid Id { get; set; }
    }
}
