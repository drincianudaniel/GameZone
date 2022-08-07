using MediatR;

namespace GameZone.Application.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, Guid>
    {
        private readonly IGenreRepository _genreRepository;
        public DeleteGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public Task<Guid> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = _genreRepository.ReturnById(request.Id);
            _genreRepository.Delete(genre.Id);
            return Task.FromResult(genre.Id);
        }
    }
}
