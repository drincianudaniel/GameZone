using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Genres.Queries.GetGenreById
{
    public class GetGenreByIdQuery : IRequest<GenreDto>
    {
        public int Id { get; set; }
    }
}
