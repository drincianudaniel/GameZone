using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Games.Queries.GetGamesPaged
{
    public class GetGamesPagedQueryHandler : IRequestHandler<GetGamesPagedQuery, IEnumerable<GameDto>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        public GetGamesPagedQueryHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GameDto>> Handle(GetGamesPagedQuery request, CancellationToken cancellationToken)
        {
            var query = await _gameRepository.ReturnPagedAsync(request.Page);
            var mappedResult = _mapper.Map<IEnumerable<GameDto>>(query);
            return mappedResult;
        }
    }
}
