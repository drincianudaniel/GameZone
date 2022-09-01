﻿using GameZone.Application.Interfaces;
using GameZone.Domain.Models;
using MediatR;

namespace GameZone.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Comment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Comment> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var commentToAdd = new Comment { UserId = request.UserId, GameId= request.GameId, Content = request.Content };

            await _unitOfWork.CommentRepository.CreateAsync(commentToAdd);
            await _unitOfWork.SaveAsync();
            var getComment = await _unitOfWork.CommentRepository.ReturnByIdAsync(commentToAdd.Id);

            return getComment;
        }
    }
}
