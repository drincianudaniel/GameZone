using GameZone.Application.Filters;
using MediatR;

namespace GameZone.Application.Games.Queries.CountAsync
{
    public class CountAsyncQuery : IRequest<int>
    { 
        public GameFilter Filter { get; set; }
    }
}
