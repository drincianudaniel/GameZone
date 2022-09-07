

using GameZone.Application.Interfaces;
using MediatR;

namespace GameZone.Application.Comments.Queries.CountAsyncGameComments
{
    public class CountAsyncGameCommentsQueryHandler : IRequestHandler<CountAsyncGameCommentsQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountAsyncGameCommentsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<int> Handle(CountAsyncGameCommentsQuery request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.GameId);
            var count = await _unitOfWork.CommentRepository.CountAsync(game);
            return count;
        }
    }
}
