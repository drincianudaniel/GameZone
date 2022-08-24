using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Comments.Commands.CreateComment;
using GameZone.Application.Comments.Commands.DeleteComment;
using GameZone.Application.Comments.Queries.GetCommentById;
using GameZone.Application.Comments.Queries.GetCommentsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    { 
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public CommentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper=mapper;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var query = new GetCommentByIdQuery { Id = Id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<CommentDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var result = await _mediator.Send(new GetCommentsListQuery());
            var mappedResult = _mapper.Map<IEnumerable<CommentDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentViewModel comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateCommentCommand
            {
                UserId = comment.UserId,
                GameId = comment.GameId,
                Content = comment.Content
            };
            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<CommentDto>(result);

            return CreatedAtAction(nameof(GetById), new { Id = mappedResult.Id }, mappedResult);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteComment(Guid Id)
        {
            var command = new DeleteCommentCommand { Id = Id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
