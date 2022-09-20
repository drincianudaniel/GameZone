using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Genres.Queries.GetGenresPaged
{
    public class GetGenresPagedQueryHandler : IRequestHandler<GetGenresPagedQuery, IEnumerable<Genre>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGenresPagedQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<Genre>> Handle(GetGenresPagedQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.GenreRepository.ReturnPagedAsync(request.Page, request.PageSize);
            return query;
        }
    }
}
