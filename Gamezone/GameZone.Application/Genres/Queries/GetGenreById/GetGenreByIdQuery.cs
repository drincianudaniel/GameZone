using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Genres.Queries.GetGenreById
{
    public class GetGenreByIdQuery : IRequest<GenreDto>
    {
        public Guid Id { get; set; }
    }
}
