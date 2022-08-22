using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.ReturnByIdAsync(request.Id);

            await _unitOfWork.UserRepository.DeleteAsync(user);
            await _unitOfWork.SaveAsync();

            return user.Id;
        }
    }
}
