using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, ReviewDto>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public GetReviewByIdQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository=reviewRepository;
            _mapper = mapper;
        }

        public async Task<ReviewDto> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _reviewRepository.ReturnByIdAsync(id);
            var reviewDto = _mapper.Map<ReviewDto>(result);
            return reviewDto;
        }
    }
}
