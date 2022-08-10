using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Reviews.Queries.GetReviewsList
{
    public class GetReviewsListQueryHandler : IRequestHandler<GetReviewsListQuery, IEnumerable<ReviewDto>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public GetReviewsListQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository=reviewRepository;
            _mapper=mapper;
        }

        public async Task<IEnumerable<ReviewDto>> Handle(GetReviewsListQuery request, CancellationToken cancellationToken)
        {
            var query = await _reviewRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<ReviewDto>>(query);
            return mappedResult;
        }
    }
}
