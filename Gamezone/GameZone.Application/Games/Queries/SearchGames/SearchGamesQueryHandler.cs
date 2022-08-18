using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Games.Queries.SearchGames
{
    public class SearchGamesQueryHandler : IRequestHandler<SearchGamesQuery, IEnumerable<SimpleGameDto>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public SearchGamesQueryHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository=gameRepository;
            _mapper=mapper;
        }

        public async Task<IEnumerable<SimpleGameDto>> Handle(SearchGamesQuery request, CancellationToken cancellationToken)
        {
            var query = await _gameRepository.SearchGameAsync(request.searchString);
            var mappedResult = _mapper.Map<IEnumerable<SimpleGameDto>>(query);
            return mappedResult;
        }
    }
}
