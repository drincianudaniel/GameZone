using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetCommentsListQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository=commentRepository;
            _mapper=mapper;
        }

        public async Task<IEnumerable<CommentDto>> Handle(GetCommentsListQuery request, CancellationToken cancellationToken)
        {
            var query = await _commentRepository.ReturnAllAsync();
            var mappedResult = _mapper.Map<IEnumerable<CommentDto>>(query);

            return mappedResult;
        }
    }
}
