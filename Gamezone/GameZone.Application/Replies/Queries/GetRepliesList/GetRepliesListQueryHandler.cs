using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Replies.Queries.GetRepliesList
{
    public class GetRepliesListQueryHandler : IRequestHandler<GetRepliesListQuery, IEnumerable<ReplyDto>>
    {
        private readonly IReplyRepository _replyRepository;
        private readonly IMapper _mapper;

        public GetRepliesListQueryHandler(IReplyRepository replyRepository, IMapper mapper)
        {
            _replyRepository=replyRepository;
            _mapper=mapper;
        }

        public async Task<IEnumerable<ReplyDto>> Handle(GetRepliesListQuery request, CancellationToken cancellationToken)
        {
            var query = await _replyRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<ReplyDto>>(query);
            return mappedResult;
        }
    }
}
