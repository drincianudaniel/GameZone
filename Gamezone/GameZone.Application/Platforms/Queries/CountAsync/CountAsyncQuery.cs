using MediatR;

namespace GameZone.Application.Platforms.Queries.CountAsync
{
    public class CountAsyncQuery : IRequest<int>
    {
        public string SearchString { get; set; }
    }
}
