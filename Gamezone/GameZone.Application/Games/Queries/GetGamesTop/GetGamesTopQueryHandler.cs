using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesTop
{
    public class GetGamesTopQueryHandler : IRequestHandler<GetGamesTopQuery, IEnumerable<SimpleGameDto>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        public GetGamesTopQueryHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SimpleGameDto>> Handle(GetGamesTopQuery request, CancellationToken cancellationToken)
        {
            var query = await _gameRepository.GenerateTopList();
            var mappedResult = _mapper.Map<IEnumerable<SimpleGameDto>>(query);
            return mappedResult;
        }
    }
}
