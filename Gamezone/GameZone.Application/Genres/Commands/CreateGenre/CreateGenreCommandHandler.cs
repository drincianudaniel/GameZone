using GameZoneModels;
using MediatR;

namespace GameZone.Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Guid>
    {
        private readonly IGenreRepository _genreRepository;

        public CreateGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public Task<Guid> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre { Name = request.Name };
            _genreRepository.Create(genre);

            return Task.FromResult(genre.Id);
        }
    }
}
