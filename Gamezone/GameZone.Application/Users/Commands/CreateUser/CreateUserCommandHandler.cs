using GameZoneModels;
using MediatR;

namespace GameZone.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var games = request.FavoriteGames.Select(gameDto => new Game { Name = gameDto.Name, ReleaseDate = gameDto.ReleaseDate, GameDetails = gameDto.GameDetails, Developers = gameDto.Developers, Genres = gameDto.Genres, Platforms = gameDto.Platforms});
            var user = new User { Email = request.Email, Username = request.Username, Password = request.Password, FirstName = request.FirstName, LastName = request.LastName, Role = request.Role, Games = games.ToList() };
            _userRepository.Create(user);
            return Task.FromResult(user.Id);
        }
    }
}
