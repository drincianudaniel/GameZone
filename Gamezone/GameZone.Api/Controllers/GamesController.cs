using AutoMapper;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Games.Commands.CreateGame;
using GameZone.Application.Games.Commands.DeleteGame;
using GameZone.Application.Games.Commands.UpdateGame;
using GameZone.Application.Games.Queries.GetGameById;
using GameZone.Application.Games.Queries.GetGamesList;
using GameZone.Application.Games.Queries.GetGamesPaged;
using GameZone.Application.Games.Queries.GetGamesTop;
using GameZone.Application.Games.Queries.GetNumberOfGames;
using GameZone.Application.Games.Queries.SearchGames;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameZone.Api.Controllers
{
    [Route("api/games")]
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
            var mappedResult = _mapper.Map<IEnumerable<GameDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetGameByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<GameDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("top")]
        public async Task<IActionResult> GetTop()
        {
            var result = await _mediator.Send(new GetGamesTopQuery());
            var mappedResult = _mapper.Map<IEnumerable<SimpleGameDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("page/{page}")]
        public async Task<IActionResult> GetGamesPaged(int page)
        {
            var result = await _mediator.Send(new GetGamesPagedQuery
            {
                Page = page
            });

            var mappedResult = _mapper.Map<IEnumerable<GameDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("search/{searchstring}")]
        public async Task<IActionResult> SearchGames(string searchstring)
        {
            var result = await _mediator.Send(new SearchGamesQuery
            {
                searchString = searchstring
            });

            var mappedResult = _mapper.Map<IEnumerable<GameDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("number/{number}")]
        public async Task<IActionResult> GetNumberOfGames(int number)
        {
            var result = await _mediator.Send(new GetNumberOfGamesQuery
            {
                Number = number
            });

            var mappedResult = _mapper.Map<IEnumerable<SimpleGameDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] GameViewModel game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
            var mappedResult = _mapper.Map<GameDto>(result);
            return CreatedAtAction(nameof(GetById), new { Id = mappedResult.Id }, mappedResult);
        }

        // not fully working yet
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateGame(Guid id, [FromBody] GameViewModel game)
        {
            var command = new UpdateGameCommand
            {
                Id = id,
                Name = game.Name,
                ReleaseDate = game.ReleaseDate,
                ImageSrc = game.ImageSrc,
                GameDetails = game.GameDetails,
                DeveloperList = game.DeveloperList,
                GenreList = game.GenreList,
                PlatformList = game.PlatformList,
            };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();
            var mappedResult = _mapper.Map<GameDto>(result);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var command = new DeleteGameCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
