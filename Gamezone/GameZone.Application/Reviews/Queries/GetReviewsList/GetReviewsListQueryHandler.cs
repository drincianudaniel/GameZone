using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Reviews.Queries.GetReviewsList
{
    public class GetReviewsListQueryHandler : IRequestHandler<GetReviewsListQuery, IEnumerable<Review>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetReviewsListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<Review>> Handle(GetReviewsListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.ReviewRepository.ReturnAllAsync();
            return query;
        }
    }
}
