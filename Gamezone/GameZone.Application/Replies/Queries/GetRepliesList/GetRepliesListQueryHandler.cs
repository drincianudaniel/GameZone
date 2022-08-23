using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Replies.Queries.GetRepliesList
{
    public class GetRepliesListQueryHandler : IRequestHandler<GetRepliesListQuery, IEnumerable<ReplyDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRepliesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }

        public async Task<IEnumerable<ReplyDto>> Handle(GetRepliesListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.ReplyRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<ReplyDto>>(query);
            return mappedResult;
        }
    }
}
