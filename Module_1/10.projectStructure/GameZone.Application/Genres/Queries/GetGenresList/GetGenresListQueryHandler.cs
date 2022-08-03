using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Genres.Queries.GetGenresList
{
    public class GetGenresListQueryHandler : IRequestHandler<GetGenresListQuery, IEnumerable<GenreDto>>
    {
        private readonly IGenreRepository _genreRepository;

        public GetGenresListQueryHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public Task<IEnumerable<GenreDto>> Handle(GetGenresListQuery request, CancellationToken cancellationToken)
        {
            var result = _genreRepository.ReturnAll().Select(genre => new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name
            });

            return Task.FromResult(result);
        }
    }
}
