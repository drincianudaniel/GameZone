using MediatR;

namespace GameZone.Application.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
