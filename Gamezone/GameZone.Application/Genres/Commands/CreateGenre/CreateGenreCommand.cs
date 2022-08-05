using MediatR;

namespace GameZone.Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}
