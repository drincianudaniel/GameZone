using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Reviews.Commands.CreateReview;
using GameZone.Application.Reviews.Commands.DeleteReview;
using GameZone.Application.Reviews.Commands.UpdateReview;
using GameZone.Application.Reviews.Queries.GetReviewById;
using GameZone.Application.Reviews.Queries.GetReviewsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Api.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;
        public readonly ILogger _logger;
        public ReviewController(IMediator mediator, IMapper mapper, ILogger<ReviewController> logger)
        {
            _mediator = mediator;
            _mapper=mapper;
            _logger=logger;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Getting item {id}", id);

            var query = new GetReviewByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning("Get({id}) NOT FOUND", id);
                return NotFound();
            }

            var mappedResult = _mapper.Map<ReviewDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            _logger.LogInformation("Getting reviews list");

            var result = await _mediator.Send(new GetReviewsListQuery());
            var mappedResult = _mapper.Map<IEnumerable<ReviewDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewViewModel review)
        {
            _logger.LogInformation("Creating review");

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

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateReview(Guid id, [FromBody] ReviewViewModel review)
        {
            _logger.LogInformation("Updating review with id {id}", id);

            var command = new UpdateReviewCommand
            {
                Id = id,
                Content = review.Content,
                Rating = review.Rating,
                UserId = review.UserId,
                GameId = review.GameId
            };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning("Result with id {id} NOT FOUND", id);
                return NotFound();
            }

            var mappedResult = _mapper.Map<ReviewDto>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            _logger.LogInformation("Deleting review with id {id}", id);

            var command = new DeleteReviewCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result == Guid.Empty)
            {
                _logger.LogWarning("Result with id {id} NOT FOUND", id);
                return NotFound();
            }

            return NoContent();
        }
    }
}
