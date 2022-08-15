using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GameZone.Application.Platforms.Queries.GetPlatformById;
using GameZone.Application.Platforms.Queries.GetPlatformsList;
using GameZone.Api.ViewModels;
using GameZone.Application.Platforms.Commands.CreatePlatform;
using GameZone.Application.Platforms.Commands.DeletePlatform;

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

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPlatforms()
        {
            var result = await _mediator.Send(new GetPlatformsListQuery());
            return Ok(result);
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

            return CreatedAtAction(nameof(GetById), new { Id = result }, result);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeletePlatform(Guid id)
        {
            var command = new DeletePlatformCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
