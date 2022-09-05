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
using GameZone.Application.Games.Queries.GamesAutoComplete;

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
        public readonly ILogger _logger;

        public GamesController(IMapper mapper, IMediator mediator, ILogger<GamesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger=logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            _logger.LogInformation("Getting list of games");

            var result = await _mediator.Send(new GetGameListQuery());
            var mappedResult = _mapper.Map<IEnumerable<GameDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Getting item {id}", id);

            var query = new GetGameByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning("Get({id}) NOT FOUND", id);
                return NotFound();
            }
                
            var mappedResult = _mapper.Map<GameDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("top")]
        public async Task<IActionResult> GetTop()
        {
            _logger.LogInformation("Getting games top");

            var result = await _mediator.Send(new GetGamesTopQuery());
            var mappedResult = _mapper.Map<IEnumerable<SimpleGameDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("page/{page}")]
        public async Task<IActionResult> GetGamesPaged(int page)
        {
            _logger.LogInformation("Getting games at page {page}", page);

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
            _logger.LogInformation("Getting games that include {searchstring}", searchstring);

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
            _logger.LogInformation("Getting first {number} games", number);

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
            _logger.LogInformation("Creating a game");

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
            _logger.LogInformation("Updating game with id {id}", id);

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
            {
                _logger.LogWarning("Result with id {id} NOT FOUND", id);
                return NotFound();
            }
               
            var mappedResult = _mapper.Map<GameDto>(result);
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            _logger.LogInformation("Deleting game with id {id}", id);

            var command = new DeleteGameCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result == Guid.Empty)
            {
                _logger.LogWarning("Result with id {id} NOT FOUND", id);
                return NotFound();
            }
                
            return NoContent();
        }

        [HttpGet]
        [Route("auto-complete/{search}")]
        public async Task<IActionResult> GameAutoComplete(string search)
        {
            var result = await _mediator.Send(new GamesAutoCompleteQuery
            {
                searchString = search
            });

            return Ok(result);
        }
    }
}
