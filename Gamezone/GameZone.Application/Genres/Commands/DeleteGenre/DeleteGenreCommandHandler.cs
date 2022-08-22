using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteGenreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _unitOfWork.GenreRepository.ReturnByIdAsync(request.Id);

            await _unitOfWork.GenreRepository.DeleteAsync(genre);
            await _unitOfWork.SaveAsync();

            return genre.Id;
        }
    }
}
