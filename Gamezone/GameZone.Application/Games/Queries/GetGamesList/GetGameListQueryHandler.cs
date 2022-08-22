using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Games.Queries.GetGamesList
{
    public class GetGameListQueryHandler : IRequestHandler<GetGameListQuery, IEnumerable<GameDto>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        public GetGameListQueryHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GameDto>> Handle(GetGameListQuery request, CancellationToken cancellationToken)
        {
            var query = await _gameRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<GameDto>>(query);
            return mappedResult;
        }        
    }
}
