using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Guid>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var userDto = _mapper.Map<User>(request.User);
            var gameDto = _mapper.Map<Game>(request.Game);
            var comment = new Comment { User = userDto, Game= gameDto, Content = request.Content };
            _commentRepository.Create(comment);
            return Task.FromResult(comment.Id);
        }
    }
}
