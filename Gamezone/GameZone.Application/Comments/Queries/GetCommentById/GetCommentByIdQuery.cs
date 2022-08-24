using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Comments.Queries.GetCommentById
{
    public class GetCommentByIdQuery : IRequest<Comment>
    {
        public Guid Id { get; set; }
    }
}
