﻿using GameZone.Application.DTOs;
using MediatR;


namespace GameZone.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<ReviewDto>
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public double Rating { get; set; }
        public string Content { get; set; }
    }
}
