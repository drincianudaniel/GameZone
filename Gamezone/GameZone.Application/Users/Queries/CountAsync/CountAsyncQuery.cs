using MediatR;

namespace GameZone.Application.Users.Queries.CountAsync
{
    public class CountAsyncQuery : IRequest<int>
    {
        public string SearchString { get; set; }
    }
}
