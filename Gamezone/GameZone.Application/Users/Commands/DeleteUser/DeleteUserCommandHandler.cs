using MediatR;

namespace GameZone.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<Guid> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.ReturnById(request.Id);
            _userRepository.Delete(user.Id);
            return Task.FromResult(user.Id);
        }
    }
}
