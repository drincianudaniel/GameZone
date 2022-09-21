using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Games.Commands.SaveAsync
{
    public class SaveAsyncCommandHandler : IRequestHandler<SaveAsyncCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaveAsyncCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<Unit> Handle(SaveAsyncCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.GameRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
