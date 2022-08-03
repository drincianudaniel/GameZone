using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Genres.Queries.GetGenreById
{
    internal class GetGenreByIdQuery : IRequest<GenreDto>
    {
    }
}
