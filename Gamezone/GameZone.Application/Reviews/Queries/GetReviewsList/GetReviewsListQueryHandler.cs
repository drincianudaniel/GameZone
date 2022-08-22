using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Reviews.Queries.GetReviewsList
{
    public class GetReviewsListQueryHandler : IRequestHandler<GetReviewsListQuery, IEnumerable<ReviewDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetReviewsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }

        public async Task<IEnumerable<ReviewDto>> Handle(GetReviewsListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.ReviewRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<ReviewDto>>(query);
            return mappedResult;
        }
    }
}
