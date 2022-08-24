using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, Genre>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGenreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Genre> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genreToUpdate = new Genre();
            genreToUpdate.Id = request.Id;
            genreToUpdate.Name = request.Name;

            await _unitOfWork.GenreRepository.UpdateAsync(genreToUpdate);
            await _unitOfWork.SaveAsync();

            return genreToUpdate;
        }
    }
}
