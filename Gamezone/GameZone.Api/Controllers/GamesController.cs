﻿using AutoMapper;
using GameZone.Api.ViewModels;
using GameZone.Application.Games.Commands.CreateGame;
using GameZone.Application.Games.Commands.DeleteGame;
using GameZone.Application.Games.Queries.GetGameById;
using GameZone.Application.Games.Queries.GetGamesList;
using GameZone.Application.Games.Queries.GetGamesTop;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        // GET: api/<GamesController>
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public GamesController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var result = await _mediator.Send(new GetGameListQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetGameByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("top")]
        public async Task<IActionResult> GetTop()
        {
            var result = await _mediator.Send(new GetGamesTopQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] GameViewModel game)
        {
            var command = new CreateGameCommand
            {
                Name = game.Name,
                ReleaseDate = game.ReleaseDate,
                ImageSrc = game.ImageSrc,
                GameDetails = game.GameDetails,
                DeveloperList = game.DeveloperList,
                GenreList = game.GenreList,
                PlatformList = game.PlatformList,
            };

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { Id = result.Id }, result);
        }


        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteGame(Guid Id)
        {
            var command = new DeleteGameCommand { Id = Id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
