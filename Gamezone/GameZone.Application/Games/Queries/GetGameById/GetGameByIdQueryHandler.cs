using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Games.Queries.GetGameById
{
    public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameDto>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GetGameByIdQueryHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        public async Task<GameDto> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _gameRepository.ReturnByIdAsync(id);
            var gameDTO = _mapper.Map<GameDto>(result);
            return gameDTO;
        }
    }
}
