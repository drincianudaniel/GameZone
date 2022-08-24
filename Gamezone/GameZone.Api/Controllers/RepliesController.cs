using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Replies.Commands.CreateReply;
using GameZone.Application.Replies.Commands.DeleteReply;
using GameZone.Application.Replies.Queries.GetRepliesList;
using GameZone.Application.Replies.Queries.GetReplyById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RepliesController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;
        public RepliesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper=mapper;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var query = new GetReplyByIdQuery { Id = Id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<ReplyDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetReplies()
        {
            var result = await _mediator.Send(new GetRepliesListQuery());
            var mappedResult = _mapper.Map<IEnumerable<ReplyDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReply([FromBody] ReplyViewModel reply)
        {
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

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteReply(Guid Id)
        {
            var command = new DeleteReplyCommand { Id = Id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
