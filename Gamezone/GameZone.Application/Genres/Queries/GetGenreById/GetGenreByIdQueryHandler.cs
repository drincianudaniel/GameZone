using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Genres.Queries.GetGenreById
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, Genre>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetGenreByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Genre> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _unitOfWork.GenreRepository.ReturnByIdAsync(id);

            return result;
        }
    }
}
