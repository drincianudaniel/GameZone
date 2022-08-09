using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Comments.Queries.GetCommentsList
{
    public class GetCommentsListQuery : IRequest<IEnumerable<CommentDto>>
    {
    }
}
