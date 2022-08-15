using AutoMapper;
using GameZone.Application.DTOs;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Replies.Commands.CreateReply
{
    public class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommand, ReplyDto>
    {
        private readonly IReplyRepository _replyRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CreateReplyCommandHandler(IReplyRepository replyRepository, IUserRepository userRepository, ICommentRepository commentRepository, IMapper mapper)
        {
            _replyRepository=replyRepository;
            _userRepository=userRepository;
            _commentRepository=commentRepository;
            _mapper=mapper;
        }

        public async Task<ReplyDto> Handle(CreateReplyCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.ReturnByIdAsync(request.UserId);
            var comment = await _commentRepository.ReturnByIdAsync(request.CommentId);
            var userDto = _mapper.Map<User>(user);
            var commentDto = _mapper.Map<Comment>(comment);
            var reply = new Reply { User = userDto, Comment = commentDto, Content = request.Content };
            await _replyRepository.CreateAsync(reply);

            var replyDto = _mapper.Map<ReplyDto>(reply);
            return replyDto;
        }
    }
}
