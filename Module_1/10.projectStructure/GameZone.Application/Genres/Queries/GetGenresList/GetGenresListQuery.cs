using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Genres.Queries.GetGenresList
{
    public class GetGenresListQuery : IRequest<IEnumerable<GenreDto>>
    {

    }
}
