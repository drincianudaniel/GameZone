using GameZone.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZone.Application.Comments.Queries.GetCommentsList
{
    public class GetCommentsListQueryHandler : IRequestHandler<GetCommentsListQuery, IEnumerable<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentsListQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository=commentRepository;
        }

        public Task<IEnumerable<CommentDto>> Handle(GetCommentsListQuery request, CancellationToken cancellationToken)
        {
            var result = _commentRepository.ReturnAll().Select(comment => new CommentDto
            {
                Id = comment.Id,
                User = comment.User,
                Game = comment.Game,
                Content = comment.Content,
            });

            return Task.FromResult(result);
        }
    }
}
