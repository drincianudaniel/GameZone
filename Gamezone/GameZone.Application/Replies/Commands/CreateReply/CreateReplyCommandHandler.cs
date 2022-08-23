using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Replies.Commands.CreateReply
{
    public class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommand, ReplyDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateReplyCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper=mapper;
            _unitOfWork=unitOfWork;
        }

        public async Task<ReplyDto> Handle(CreateReplyCommand request, CancellationToken cancellationToken)
        {
            var reply = new Reply { UserId = request.UserId, CommentId = request.CommentId, Content = request.Content };

            await _unitOfWork.ReplyRepository.CreateAsync(reply);
            await _unitOfWork.SaveAsync();

            var replyDto = _mapper.Map<ReplyDto>(reply);
            return replyDto;
        }
    }
}
