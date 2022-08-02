using AutoMapper;
using GameZoneModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Games.Queries.GetGameById
{
    public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameDto>
    {
        private readonly IGameRepository _gameRepository;

        public GetGameByIdQueryHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public Task<GameDto> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            int id = request.Id;
            
            var result = _gameRepository.ReturnById(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Game, GameDto>());
            var mapper = new Mapper(config);
            var gameDTO = mapper.Map<GameDto>(result);
            return Task.FromResult(gameDTO);
        }
    }
}
