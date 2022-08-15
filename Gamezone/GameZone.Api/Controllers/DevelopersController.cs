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

        public DevelopersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var query = new GetDeveloperByIdQuery { Id = Id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetDevelopers()
        {
            var result = await _mediator.Send(new GetDevelopersListQuery());
            return Ok(result);
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

            return CreatedAtAction(nameof(GetById), new { Id = result }, result);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteDeveloper(Guid id)
        {
            var command = new DeleteDeveloperCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
