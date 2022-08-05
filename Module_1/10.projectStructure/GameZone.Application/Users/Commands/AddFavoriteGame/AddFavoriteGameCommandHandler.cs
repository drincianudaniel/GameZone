using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Users.Commands.AddFavoriteGame
{
    public class AddFavoriteGameCommandHandler : IRequestHandler<AddFavoriteGameCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public AddFavoriteGameCommandHandler(IUserRepository userRepository, IGameRepository gameRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        public Task<int> Handle(AddFavoriteGameCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.ReturnById(request.IdUser);
            var game = _gameRepository.ReturnById(request.IdGame);
            _userRepository.AddGameToFavorite(user, game);
            return Task.FromResult(game.Id);
        }
    }
}
