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

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var query = new GetCommentByIdQuery { Id = Id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var result = await _mediator.Send(new GetCommentsListQuery());
            return Ok(result);
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

            return CreatedAtAction(nameof(GetById), new { Id = result }, result);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var command = new DeleteCommentCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
