using MediatR;

namespace GameZone.Application.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
