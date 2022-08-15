using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CommentDto>
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

        public async Task<CommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.ReturnByIdAsync(request.UserId);
            var game = await _gameRepository.ReturnByIdAsync(request.GameId);
            var userDto = _mapper.Map<User>(user);
            var gameDto = _mapper.Map<Game>(game);
            var comment = new Comment { User = userDto, Game= gameDto, Content = request.Content };
            await _commentRepository.CreateAsync(comment);

            var commentDto = _mapper.Map<CommentDto>(comment);
            return commentDto;
        }
    }
}
