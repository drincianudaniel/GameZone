using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { Email = request.Email, Username = request.Username, Password = request.Password, FirstName = request.FirstName, LastName = request.LastName, Role = request.Role};
            
            await _unitOfWork.UserRepository.CreateAsync(user);
            await _unitOfWork.SaveAsync();

            return user;
        }
    }
}
