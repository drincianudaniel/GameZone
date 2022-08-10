using AutoMapper;
using GameZone.Application.DTOs;
using MediatR;

namespace GameZone.Application.Comments.Queries.GetCommentById
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentDto>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository=commentRepository;
            _mapper=mapper;
        }
        public async Task<CommentDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = await _commentRepository.ReturnByIdAsync(id);
            var commentDto = _mapper.Map<CommentDto>(result);
            return commentDto;
        }
    }
}
