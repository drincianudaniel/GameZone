using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Replies.Commands.CreateReply;
using GameZone.Application.Replies.Commands.DeleteReply;
using GameZone.Application.Replies.Commands.UpdateReply;
using GameZone.Application.Replies.Queries.GetRepliesList;
using GameZone.Application.Replies.Queries.GetReplyById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Api.Controllers
{

    [Route("api/replies")]
    [ApiController]
    public class RepliesController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;
        public readonly ILogger _logger;

        public RepliesController(IMediator mediator, IMapper mapper, ILogger<RepliesController> logger)
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

            var query = new GetReplyByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning("Get({id}) NOT FOUND", id);
                return NotFound();
            }

            var mappedResult = _mapper.Map<ReplyDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetReplies()
        {
            _logger.LogInformation("Getting replies list");

            var result = await _mediator.Send(new GetRepliesListQuery());
            var mappedResult = _mapper.Map<IEnumerable<ReplyDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReply([FromBody] ReplyViewModel reply)
        {
            _logger.LogInformation("Creating reply");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateReplyCommand
            {
                UserId = reply.UserId,
                CommentId = reply.CommentId,
                Content = reply.Content,
            };
            var result = await _mediator.Send(command);

            var mappedResult = _mapper.Map<ReplyDto>(result);
            return CreatedAtAction(nameof(GetById), new { Id = mappedResult.Id }, mappedResult);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateReply(Guid id, [FromBody] ReplyViewModel reply)
        {
            _logger.LogInformation("Updating reply with id {id}", id);

            var command = new UpdateReplyCommand
            {
                Id = id,
                Content = reply.Content,
                UserId = reply.UserId,
                CommentId = reply.CommentId
            };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning("Result with id {id} NOT FOUND", id);
                return NotFound();
            }

            var mappedResult = _mapper.Map<ReplyDto>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteReply(Guid id)
        {
            _logger.LogInformation("Deleting reply with id {id}", id);

            var command = new DeleteReplyCommand { Id = id };
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
