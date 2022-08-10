using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Genres.Queries.GetGenresList
{
    public class GetGenresListQueryHandler : IRequestHandler<GetGenresListQuery, IEnumerable<GenreDto>>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GetGenresListQueryHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper=mapper;
        }

        public async Task<IEnumerable<GenreDto>> Handle(GetGenresListQuery request, CancellationToken cancellationToken)
        {
            var query = await _genreRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<GenreDto>>(query);

            return mappedResult;
        }
    }
}
