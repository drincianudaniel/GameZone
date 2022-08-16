using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommand : IRequest<GenreDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
