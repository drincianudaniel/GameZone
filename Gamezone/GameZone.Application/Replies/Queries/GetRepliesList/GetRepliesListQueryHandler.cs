using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Replies.Queries.GetRepliesList
{
    public class GetRepliesListQueryHandler : IRequestHandler<GetRepliesListQuery, IEnumerable<Reply>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRepliesListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<Reply>> Handle(GetRepliesListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.ReplyRepository.ReturnAllAsync();
            return query;
        }
    }
}
