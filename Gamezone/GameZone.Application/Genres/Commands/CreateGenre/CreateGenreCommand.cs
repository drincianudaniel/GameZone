using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<Genre>
    {
        public string Name { get; set; } = string.Empty;
    }
}
