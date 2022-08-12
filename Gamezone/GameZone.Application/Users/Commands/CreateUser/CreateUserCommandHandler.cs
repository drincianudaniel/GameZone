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
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { Email = request.Email, Username = request.Username, Password = request.Password, FirstName = request.FirstName, LastName = request.LastName, Role = request.Role};
            await _userRepository.CreateAsync(user);
            return user.Id;
        }
    }
}
