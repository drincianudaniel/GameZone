using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Genre>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateGenreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Genre> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre { Name = request.Name };

            await _unitOfWork.GenreRepository.CreateAsync(genre);
            await _unitOfWork.SaveAsync();

            return genre;
        }
    }
}
