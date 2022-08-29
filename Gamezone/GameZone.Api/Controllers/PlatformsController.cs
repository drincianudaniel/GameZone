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

namespace GameZone.Api.Controllers
{
    [Route("api/platforms")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public PlatformsController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetPlatformByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<PlatformDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetPlatforms()
        {
            var result = await _mediator.Send(new GetPlatformsListQuery());
            var mappedResult = _mapper.Map<IEnumerable<PlatformDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlatform([FromBody] PlatformViewModel platform)
        {
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
            var command = new UpdatePlatformCommand
            {
                Id = id,
                Name= platform.Name
            };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<PlatformDto>(result);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePlatform(Guid id)
        {
            var command = new DeletePlatformCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
