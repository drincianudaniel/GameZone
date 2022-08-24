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
    [Route("api/[controller]")]
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
        [Route("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var query = new GetPlatformByIdQuery { Id = Id };
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
        [Route("{Id}")]
        public async Task<IActionResult> UpdatePlatform(Guid Id, [FromBody] PlatformViewModel platform)
        {
            var command = new UpdatePlatformCommand
            {
                Id = Id,
                Name= platform.Name
            };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<PlatformDto>(result);
            return NoContent();
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeletePlatform(Guid Id)
        {
            var command = new DeletePlatformCommand { Id = Id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
