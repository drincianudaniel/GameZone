using AutoMapper;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Guid>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, IGameRepository gameRepository, IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _gameRepository=gameRepository;
            _userRepository=userRepository;
        }

        public Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {

            var userDto = _mapper.Map<User>(_userRepository.ReturnById(request.UserId));
            var gameDto = _mapper.Map<Game>(_gameRepository.ReturnById(request.GameId));
            var comment = new Comment { User = userDto, Game= gameDto, Content = request.Content };
            _commentRepository.Create(comment);
            return Task.FromResult(comment.Id);
        }
    }
}
