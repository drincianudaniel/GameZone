using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CommentDto>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var commentToAdd = new Comment { UserId = request.UserId, GameId= request.GameId, Content = request.Content };
            await _commentRepository.CreateAsync(commentToAdd);
            var getComment = await _commentRepository.ReturnByIdAsync(commentToAdd.Id);
            var commentDto = _mapper.Map<CommentDto>(getComment);

            return commentDto;
        }
    }
}
