using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Platforms.Queries.GetPlatformsPaged
{
    public class GetPlatformsPagedQuery : IRequest<IEnumerable<Platform>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
