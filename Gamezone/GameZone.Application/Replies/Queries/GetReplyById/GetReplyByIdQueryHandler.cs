using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Replies.Queries.GetReplyById
{
    public class GetReplyByIdQueryHandler : IRequestHandler<GetReplyByIdQuery, ReplyDto>
    {
        private readonly IReplyRepository _replyRepository;
        private readonly IMapper _mapper;

        public GetReplyByIdQueryHandler(IReplyRepository replyRepository, IMapper mapper)
        {
            _replyRepository=replyRepository;
            _mapper=mapper;
        }
        public async Task<ReplyDto> Handle(GetReplyByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _replyRepository.ReturnByIdAsync(id);
            var replyDto = _mapper.Map<ReplyDto>(result);
            return replyDto;
        }
    }
}
