using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Comments.Queries.GetGameComments
{
    public class GetGameCommentsHandler : IRequestHandler<GetGameCommentsQuery, IEnumerable<Comment>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGameCommentsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<IEnumerable<Comment>> Handle(GetGameCommentsQuery request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.ReturnByIdAsync(request.GameId);
            var comments = await _unitOfWork.CommentRepository.ReturnGameComments(game, request.Page, request.PageSize);

            return comments;
        }
    }
}
