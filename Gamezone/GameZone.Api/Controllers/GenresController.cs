using AutoMapper;
using GameZone.Application.Genres.Commands.CreateGenre;
using GameZone.Application.Genres.Queries.GetGenreById;
using GameZone.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GameZone.Application.Genres.Queries.GetGenresList;
using GameZone.Application.Genres.Commands.DeleteGenre;
using GameZone.Application.Genres.Commands.UpdateGenre;
using GameZone.Api.DTOs;

namespace GameZone.Api.Controllers
{
    [Route("api/genres")]
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
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetGenreByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if(result == null)
                return NotFound();

            var mappedResult = _mapper.Map<GenreDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var result = await _mediator.Send(new GetGenresListQuery());
            var mappedResult = _mapper.Map<IEnumerable<GenreDto>>(result);
            return Ok(mappedResult);
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
            var mappedResult = _mapper.Map<GenreDto>(result);
            return CreatedAtAction(nameof(GetById), new { Id = mappedResult.Id }, mappedResult);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateGenre(Guid id, [FromBody] GenreViewModel genre)
        {
            var command = new UpdateGenreCommand
            {
                Id = id,
                Name= genre.Name
            };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<GenreDto>(result);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            var command = new DeleteGenreCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
