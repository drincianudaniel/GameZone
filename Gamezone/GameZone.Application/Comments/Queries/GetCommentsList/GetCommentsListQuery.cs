using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Comments.Queries.GetCommentsList
{
    public class GetCommentsListQuery : IRequest<IEnumerable<Comment>>
    {
    }
}
