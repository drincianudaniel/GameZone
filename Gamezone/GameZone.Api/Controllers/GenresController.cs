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
using GameZone.Application.Genres.Queries.GetGenresPaged;
using GameZone.Application.Genres.Queries.CountAsync;

namespace GameZone.Api.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;
        public readonly ILogger _logger;
        public GenresController(IMapper mapper, IMediator mediator, ILogger<GenresController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger=logger;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Getting item {id}", id);

            var query = new GetGenreByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning("Get({id}) NOT FOUND", id);
                return NotFound();
            }

            var mappedResult = _mapper.Map<GenreDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            _logger.LogInformation("Getting list of genres");
            var result = await _mediator.Send(new GetGenresListQuery());
            var mappedResult = _mapper.Map<IEnumerable<GenreDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("page/{page}/page-size/{pageSize}")]
        public async Task<IActionResult> GetGenresPaged(int page, int pageSize)
        {
            _logger.LogInformation("Getting genres at page {page}", page);

            var result = await _mediator.Send(new GetGenresPagedQuery
            {
                Page = page,
                PageSize = pageSize
            });

            var count = await _mediator.Send(new CountAsyncQuery());
            var totalPages = ((double)count / (double)pageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            var mappedResult = _mapper.Map<IEnumerable<GenreDto>>(result);
            return Ok(new PagedResponse<IEnumerable<GenreDto>>(mappedResult, page, count, roundedTotalPages, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] GenreViewModel genre)
        {
            _logger.LogInformation("Creating genre");

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
            _logger.LogInformation("Updating genre with id {id}", id);

            var command = new UpdateGenreCommand
            {
                Id = id,
                Name= genre.Name
            };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning("Result with id {id} NOT FOUND", id);
                return NotFound();
            }

            var mappedResult = _mapper.Map<GenreDto>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            _logger.LogInformation("Deleting genre with id {id}", id);

            var command = new DeleteGenreCommand { Id = id };
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
