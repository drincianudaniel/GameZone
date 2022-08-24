using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;


namespace GameZone.Application.Genres.Queries.GetGenresList
{
    public class GetGenresListQueryHandler : IRequestHandler<GetGenresListQuery, IEnumerable<Genre>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGenresListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Genre>> Handle(GetGenresListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.GenreRepository.ReturnAllAsync();
            return query;
        }
    }
}
