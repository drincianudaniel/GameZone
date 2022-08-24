using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Replies.Queries.GetRepliesList
{
    public class GetRepliesListQuery : IRequest<IEnumerable<Reply>>
    {
    }
}
