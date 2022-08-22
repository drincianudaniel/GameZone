using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Developers.Commands.DeleteDeveloper
{
    public class DeleteDeveloperCommandHandler : IRequestHandler<DeleteDeveloperCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDeveloperCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = await _unitOfWork.DeveloperRepository.ReturnByIdAsync(request.Id);

            await _unitOfWork.DeveloperRepository.DeleteAsync(developer);
            await _unitOfWork.SaveAsync();

            return developer.Id;
        }
    }
}
