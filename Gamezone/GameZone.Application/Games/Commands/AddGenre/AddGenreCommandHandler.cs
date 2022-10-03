using GameZone.Application.Interfaces;
using MediatR;


namespace GameZone.Application.Games.Commands.AddGenre
{
    public class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddGenreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<bool> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {

            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.GameId);
            var genre = await _unitOfWork.GenreRepository.ReturnByIdAsync(request.GenreId);
            await _unitOfWork.GameRepository.AddGenreAsync(game, genre);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
