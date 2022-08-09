using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Replies.Queries.GetRepliesList
{
    public class GetRepliesListQuery : IRequest<IEnumerable<ReplyDto>>
    {
    }
}
