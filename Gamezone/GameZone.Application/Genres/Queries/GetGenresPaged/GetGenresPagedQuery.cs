using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Genres.Queries.GetGenresPaged
{
    public class GetGenresPagedQuery : IRequest<IEnumerable<Genre>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
