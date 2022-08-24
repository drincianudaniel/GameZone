using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Replies.Queries.GetReplyById
{
    public class GetReplyByIdQueryHandler : IRequestHandler<GetReplyByIdQuery, Reply>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetReplyByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public async Task<Reply> Handle(GetReplyByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _unitOfWork.ReplyRepository.ReturnByIdAsync(id);
            return result;
        }
    }
}
