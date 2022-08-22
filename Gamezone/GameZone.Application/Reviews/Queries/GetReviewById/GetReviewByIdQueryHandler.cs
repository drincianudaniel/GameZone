using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, ReviewDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetReviewByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReviewDto> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _unitOfWork.ReviewRepository.ReturnByIdAsync(id);
            var reviewDto = _mapper.Map<ReviewDto>(result);
            return reviewDto;
        }
    }
}
