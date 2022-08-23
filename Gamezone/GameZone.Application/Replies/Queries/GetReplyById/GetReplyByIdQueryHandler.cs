using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Replies.Queries.GetReplyById
{
    public class GetReplyByIdQueryHandler : IRequestHandler<GetReplyByIdQuery, ReplyDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetReplyByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }
        public async Task<ReplyDto> Handle(GetReplyByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _unitOfWork.ReplyRepository.ReturnByIdAsync(id);
            var replyDto = _mapper.Map<ReplyDto>(result);
            return replyDto;
        }
    }
}
