using AutoMapper;
using GameZone.Application.DTOs;
using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CommentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var commentToAdd = new Comment { UserId = request.UserId, GameId= request.GameId, Content = request.Content };

            await _unitOfWork.CommentRepository.CreateAsync(commentToAdd);
            await _unitOfWork.SaveAsync();
            //var getComment = await _commentRepository.ReturnByIdAsync(commentToAdd.Id);
            var commentDto = _mapper.Map<CommentDto>(commentToAdd);

            return commentDto;
        }
    }
}
