using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Comments.Queries.GetGameComments
{
    public class GetGameCommentsQuery : IRequest<IEnumerable<Comment>>
    {
        public Guid GameId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
