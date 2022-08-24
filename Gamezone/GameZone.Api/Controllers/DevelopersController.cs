using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Developers.Commands.CreateDeveloper;
using GameZone.Application.Developers.Commands.DeleteDeveloper;
using GameZone.Application.Developers.Queries.GetDeveloperById;
using GameZone.Application.Developers.Queries.GetDevelopersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public DevelopersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper=mapper;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var query = new GetDeveloperByIdQuery { Id = Id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<DeveloperDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetDevelopers()
        {
            var result = await _mediator.Send(new GetDevelopersListQuery());
            var mappedResult = _mapper.Map<IEnumerable<DeveloperDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeveloper([FromBody] DeveloperViewModel developer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateDeveloperCommand
            {
                Name = developer.Name,
                HeadQuarters = developer.HeadQuarters
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<DeveloperDto>(result);

            return CreatedAtAction(nameof(GetById), new { Id = mappedResult.Id }, mappedResult);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteDeveloper(Guid Id)
        {
            var command = new DeleteDeveloperCommand { Id = Id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
