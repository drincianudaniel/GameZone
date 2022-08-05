using GameZoneModels;
using MediatR;

namespace GameZone.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var games = request.FavoriteGames.Select(gameDto => new Game(gameDto.Name, gameDto.ReleaseDate, gameDto.GameDetails, gameDto.Developers, gameDto.Genres, gameDto.Platforms));
            var user = new User(request.Email, request.Username, request.Password, request.FirstName, request.LastName, request.Role, games.ToList());
            _userRepository.Create(user);
            return Task.FromResult(user.Id);
        }
    }
}
