using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GameZone.Application.Platforms.Queries.GetPlatformById;
using GameZone.Application.Platforms.Queries.GetPlatformsList;
using GameZone.Api.ViewModels;
using GameZone.Application.Platforms.Commands.CreatePlatform;
using GameZone.Application.Platforms.Commands.DeletePlatform;
using GameZone.Application.Platforms.Commands.UpdatePlatform;
using GameZone.Api.DTOs;
using GameZone.Application.Platforms.Queries.GetPlatformsPaged;
using GameZone.Application.Platforms.Queries.CountAsync;

namespace GameZone.Api.Controllers
{
    [Route("api/platforms")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;
        public readonly ILogger _logger;

        public PlatformsController(IMapper mapper, IMediator mediator, ILogger<PlatformsController> logger)
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

            var query = new GetPlatformByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning("Get({id}) NOT FOUND", id);
                return NotFound();
            }

            var mappedResult = _mapper.Map<PlatformDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetPlatforms()
        {
            _logger.LogInformation("Getting list of platforms");

            var result = await _mediator.Send(new GetPlatformsListQuery());
            var mappedResult = _mapper.Map<IEnumerable<PlatformDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("page/{page}/page-size/{pageSize}")]
        public async Task<IActionResult> GetGenresPaged(int page, int pageSize)
        {
            _logger.LogInformation("Getting platforms at page {page}", page);

            var result = await _mediator.Send(new GetPlatformsPagedQuery
            {
                Page = page,
                PageSize = pageSize
            });

            var count = await _mediator.Send(new CountAsyncQuery());
            var totalPages = ((double)count / (double)pageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            var mappedResult = _mapper.Map<IEnumerable<PlatformDto>>(result);
            return Ok(new PagedResponse<IEnumerable<PlatformDto>>(mappedResult, page, count, roundedTotalPages, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlatform([FromBody] PlatformViewModel platform)
        {
            _logger.LogInformation("Creating platform");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreatePlatformCommand
            {
                Name = platform.Name,
            };
            var result = await _mediator.Send(command);

            var mappedResult = _mapper.Map<PlatformDto>(result);
            return CreatedAtAction(nameof(GetById), new { Id = mappedResult.Id }, mappedResult);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePlatform(Guid id, [FromBody] PlatformViewModel platform)
        {
            _logger.LogInformation("Updating platform with id {id}", id);

            var command = new UpdatePlatformCommand
            {
                Id = id,
                Name= platform.Name
            };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning("Result with id {id} NOT FOUND", id);
                return NotFound();
            }

            var mappedResult = _mapper.Map<PlatformDto>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePlatform(Guid id)
        {
            _logger.LogInformation("Deleting platform with id {id}", id);

            var command = new DeletePlatformCommand { Id = id };
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
