using AutoMapper;
using GameZoneModels;
using MediatR;

namespace GameZone.Application.Replies.Commands.CreateReply
{
    public class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommand, Guid>
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

        public Task<Guid> Handle(CreateReplyCommand request, CancellationToken cancellationToken)
        {
            var userDto = _mapper.Map<User>(_userRepository.ReturnById(request.UserId));
            var commentDto = _mapper.Map<Comment>(_commentRepository.ReturnById(request.CommentId));
            var reply = new Reply { User = userDto, Comment = commentDto, Content = request.Content };
            _replyRepository.Create(reply);
            return Task.FromResult(reply.Id);
        }
    }
}
