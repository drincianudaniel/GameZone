using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Genres.Queries.GetGenresList
{
    public class GetGenresListQuery : IRequest<IEnumerable<Genre>>
    {
    }
}
