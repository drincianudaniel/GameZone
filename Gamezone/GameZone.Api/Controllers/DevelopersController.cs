﻿using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Developers.Commands.CreateDeveloper;
using GameZone.Application.Developers.Commands.DeleteDeveloper;
using GameZone.Application.Developers.Commands.UpdateDeveloper;
using GameZone.Application.Developers.Queries.GetDeveloperById;
using GameZone.Application.Developers.Queries.GetDevelopersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Api.Controllers
{
    [Route("api/developers")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;
        public readonly ILogger _logger;

        public DevelopersController(IMediator mediator, IMapper mapper, ILogger<DevelopersController> logger)
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

            var query = new GetDeveloperByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning("Get({id}) NOT FOUND", id);
                return NotFound();
            }

            var mappedResult = _mapper.Map<DeveloperDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetDevelopers()
        {
            _logger.LogInformation("Getting developers list");

            var result = await _mediator.Send(new GetDevelopersListQuery());
            var mappedResult = _mapper.Map<IEnumerable<DeveloperDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeveloper([FromBody] DeveloperViewModel developer)
        {
            _logger.LogInformation("Creating developer");

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

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateGenre(Guid id, [FromBody] DeveloperViewModel developer)
        {
            _logger.LogInformation("Updating developer with id {id}", id);

            var command = new UpdateDeveloperCommand
            {
                Id = id,
                Name= developer.Name,
                HeadQuarters = developer.HeadQuarters
            };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning("Result with id {id} NOT FOUND", id);
                return NotFound();
            }

            var mappedResult = _mapper.Map<DeveloperDto>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDeveloper(Guid id)
        {
            _logger.LogInformation("Deleting developer with id {id}", id);

            var command = new DeleteDeveloperCommand { Id = id };
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
