using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommand : IRequest<Genre>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
