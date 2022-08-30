﻿using AutoMapper;
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
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    { 
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;
        public readonly ILogger _logger;

        public CommentsController(IMediator mediator, IMapper mapper, ILogger<CommentsController> logger)
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

            var query = new GetCommentByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning("Get({id}) NOT FOUND", id);
                return NotFound();
            }

            var mappedResult = _mapper.Map<CommentDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            _logger.LogInformation("Getting list of comments");

            var result = await _mediator.Send(new GetCommentsListQuery());
            var mappedResult = _mapper.Map<IEnumerable<CommentDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentViewModel comment)
        {
            _logger.LogInformation("Creating comment");

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
        [Route("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            _logger.LogInformation("Deleting comment with id {id}", id);

            var command = new DeleteCommentCommand { Id = id };
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
