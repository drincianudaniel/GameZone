using MediatR;

namespace GameZone.Application.Genres.Queries.CountAsync
{
    public class CountAsyncQuery : IRequest<int>
    {
        public string SearchString { get; set; }
    }
}
