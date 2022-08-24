using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Reviews.Commands.CreateReview;
using GameZone.Application.Reviews.Commands.DeleteReview;
using GameZone.Application.Reviews.Queries.GetReviewById;
using GameZone.Application.Reviews.Queries.GetReviewsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;
        public ReviewController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper=mapper;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var query = new GetReviewByIdQuery { Id = Id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<ReviewDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            var result = await _mediator.Send(new GetReviewsListQuery());
            var mappedResult = _mapper.Map<IEnumerable<ReviewDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewViewModel review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateReviewCommand
            {
                UserId = review.UserId,
                GameId = review.GameId,
                Rating = review.Rating,
                Content = review.Content,
            };
            var result = await _mediator.Send(command);

            var mappedResult = _mapper.Map<ReviewDto>(result);
            return CreatedAtAction(nameof(GetById), new { Id = mappedResult.Id }, mappedResult);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteReview(Guid Id)
        {
            var command = new DeleteReviewCommand { Id = Id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
