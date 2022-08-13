using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<GenreDto>
    {
        public string Name { get; set; } = string.Empty;
    }
}
