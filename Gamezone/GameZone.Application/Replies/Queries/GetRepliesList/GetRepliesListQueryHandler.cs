using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Replies.Queries.GetRepliesList
{
    public class GetRepliesListQueryHandler : IRequestHandler<GetRepliesListQuery, IEnumerable<ReplyDto>>
    {
        private readonly IReplyRepository _replyRepository;

        public GetRepliesListQueryHandler(IReplyRepository replyRepository)
        {
            _replyRepository=replyRepository;
        }

        public Task<IEnumerable<ReplyDto>> Handle(GetRepliesListQuery request, CancellationToken cancellationToken)
        {
            var result = _replyRepository.ReturnAll().Select(reply => new ReplyDto
            {
                Id = reply.Id,
                User = reply.User,
                Comment = reply.Comment,
                Content = reply.Content,
            });

            return Task.FromResult(result);
        }
    }
}
