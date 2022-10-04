using GameZone.Application.Interfaces;
using MediatR;


namespace GameZone.Application.Games.Commands.AddDeveloper
{
    public class AddDeveloperCommandHandler : IRequestHandler<AddDeveloperCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddDeveloperCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<bool> Handle(AddDeveloperCommand request, CancellationToken cancellationToken)
        {

            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.GameId);
            var developer = await _unitOfWork.DeveloperRepository.ReturnByIdAsync(request.DeveloperId);
            await _unitOfWork.GameRepository.AddDeveloper(game, developer);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}