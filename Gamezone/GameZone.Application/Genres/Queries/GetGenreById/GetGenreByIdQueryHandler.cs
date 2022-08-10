using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Genres.Queries.GetGenreById
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreDto>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GetGenreByIdQueryHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public async Task<GenreDto> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _genreRepository.ReturnByIdAsync(id);
            var genreDto = _mapper.Map<GenreDto>(result);
            return genreDto;
        }
    }
}
