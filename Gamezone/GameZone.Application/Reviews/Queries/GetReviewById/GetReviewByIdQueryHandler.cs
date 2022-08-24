using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, Review>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetReviewByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<Review> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _unitOfWork.ReviewRepository.ReturnByIdAsync(id);
            return result;
        }
    }
}
