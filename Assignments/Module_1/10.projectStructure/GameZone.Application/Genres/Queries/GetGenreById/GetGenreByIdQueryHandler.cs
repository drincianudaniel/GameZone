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
        public Task<GenreDto> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            int id = request.Id;
            var result = _genreRepository.ReturnById(id);
            var genreDto = _mapper.Map<GenreDto>(result);
            return Task.FromResult(genreDto);
        }
    }
}
