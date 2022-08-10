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
        public async Task<Guid> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.ReturnByIdAsync(request.Id);
            await _genreRepository.DeleteAsync(genre);
            return genre.Id;
        }
    }
}
