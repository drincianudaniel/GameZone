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
        public async Task<Guid> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre { Name = request.Name };
            await _genreRepository.CreateAsync(genre);

            return genre.Id;
        }
    }
}
