using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Games.Commands.RemoveGenre
{
    public class RemoveGenreCommandHandler : IRequestHandler<RemoveGenreCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveGenreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<bool> Handle(RemoveGenreCommand request, CancellationToken cancellationToken)
        {

            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.GameId);
            var genre = await _unitOfWork.GenreRepository.ReturnByIdAsync(request.GenreId);
            await _unitOfWork.GameRepository.RemoveGenreAsync(game, genre);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
