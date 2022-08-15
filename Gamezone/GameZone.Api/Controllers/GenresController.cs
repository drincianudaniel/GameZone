﻿using AutoMapper;
using GameZone.Application.Genres.Commands.CreateGenre;
using GameZone.Application.Genres.Queries.GetGenreById;
using GameZone.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GameZone.Application.Genres.Queries.GetGenresList;
using GameZone.Application.Genres.Commands.DeleteGenre;

namespace GameZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public GenresController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var query = new GetGenreByIdQuery { Id = Id };
            var result = await _mediator.Send(query);

            if(result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var result = await _mediator.Send(new GetGenresListQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] GenreViewModel genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateGenreCommand
            {
                Name = genre.Name,
            };
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { Id = result }, result);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            var command = new DeleteGenreCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}