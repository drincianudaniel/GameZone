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
        public Task<CommentDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var result = _commentRepository.ReturnById(id);
            var commentDto = _mapper.Map<CommentDto>(result);
            return Task.FromResult(commentDto);
        }
    }
}
