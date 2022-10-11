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
using GameZone.Application.Games.Queries.CountAsync;
using Microsoft.AspNetCore.JsonPatch;
using GameZone.Application.Games.Commands.SaveAsync;
using Microsoft.AspNetCore.Authorization;
using GameZone.Application.Games.Queries.GetGamesWithUserFavorites;
using GameZone.Application.Users.Queries.FindUserByName;
using GameZone.Application.Games.Commands.AddGenre;
using GameZone.Application.Games.Commands.RemoveGenre;
using GameZone.Application.Games.Commands.RemovePlatform;
using GameZone.Application.Games.Commands.RemoveDeveloper;
using GameZone.Application.Games.Commands.AddDeveloper;
using GameZone.Application.Games.Commands.AddPlatform;
using System.Security.Claims;
using GameZone.Application.Games.Queries.GetGameWithoutFavById;
using GameZone.Application.Filters;

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
        [Authorize(Roles = "Admin")]
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
            string claim = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var query = new GetGameByIdQuery { Id = id, UserName = claim };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning("Get({id}) NOT FOUND", id);
                return NotFound();
            }
                
            var mappedResult = _mapper.Map<GameWithFavoriteDTO>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("top/page/{page}/page-size/{pageSize}")]
        public async Task<IActionResult> GetTop(int page, int pageSize, [FromQuery] GameFilter filter = null)
        {
            _logger.LogInformation("Getting games top");

            var result = await _mediator.Send(new GetGamesTopQuery
            {
                Page = page,
                PageSize = pageSize
            });

            var count = await _mediator.Send(new CountAsyncQuery { Filter = filter});
            var totalPages = ((double)count / (double)pageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            var mappedResult = _mapper.Map<IEnumerable<SimpleGameDto>>(result);
            return Ok(new PagedResponse<IEnumerable<SimpleGameDto>>(mappedResult, page, count, roundedTotalPages, pageSize));
        }

        [HttpGet]
        [Route("page/{page}/page-size/{pageSize}")]
        public async Task<IActionResult> GetGamesPaged(int page, int pageSize, [FromQuery] GameFilter filter = null)
        {
            _logger.LogInformation("Getting games at page {page}", page);

            var result = await _mediator.Send(new GetGamesPagedQuery
            {
                Page = page,
                PageSize = pageSize,
                Filter = filter
            });

            var count = await _mediator.Send(new CountAsyncQuery { Filter = filter});
            var totalPages = ((double)count / (double)pageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            var mappedResult = _mapper.Map<IEnumerable<SimpleGameDto>>(result);
            return Ok(new PagedResponse<IEnumerable<SimpleGameDto>>(mappedResult, page, count, roundedTotalPages, pageSize));
        }

        [HttpGet]
        [Route("user/{username}/page/{page}/page-size/{pageSize}")]
        public async Task<IActionResult> GetGamesPagedUserFavorites(int page, int pageSize, string username, [FromQuery] GameFilter filter = null)
        {
            _logger.LogInformation("Getting games at page {page}", page);

            var query = new FindUserByNameQuery
            {
                UserName = username,
            };

            var userFound = await _mediator.Send(query);

            if (userFound == null)
            {
                return NotFound();
            };

            var result = await _mediator.Send(new GetGamesWithUserFavoritesQuery
            {
                Page = page,
                PageSize = pageSize,
                UserName = username,
                Filter = filter
            });

            var count = await _mediator.Send(new CountAsyncQuery { Filter = filter});
            var totalPages = ((double)count / (double)pageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            var mappedResult = _mapper.Map<IEnumerable<GamesWithFavoritesDto>>(result);
            return Ok(new PagedResponse<IEnumerable<GamesWithFavoritesDto>>(mappedResult, page, count, roundedTotalPages, pageSize));
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
        [Route("number/{number}/sort-order/{sortOrder}")]
        public async Task<IActionResult> GetNumberOfGames(int number, string sortOrder)
        {
            _logger.LogInformation("Getting first {number} games", number);

            var result = await _mediator.Send(new GetNumberOfGamesQuery
            {
                Number = number,
                SortOrder = sortOrder
            });

            var mappedResult = _mapper.Map<IEnumerable<SimpleGameDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [HttpPatch]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PartiallyUpdateGame(Guid id, JsonPatchDocument<GamePatchDto> patchDocument)
        {
            _logger.LogInformation("Patching game with id {id}", id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = new GetGameWithoutFavByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            var gameToPatch = _mapper.Map<GamePatchDto>(result);

            patchDocument.ApplyTo(gameToPatch, ModelState);

            if (!TryValidateModel(gameToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(gameToPatch, result);
            var command = new SaveAsyncCommand();
            var save = await _mediator.Send(command);

            return Content("The item has been updated!");

        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
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

            var mappedResult = _mapper.Map<IEnumerable<AutoCompleteGameDto>>(result);

            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("game/{gameid}/genre/{genreid}")]
        public async Task<IActionResult> AddGenreToGame(Guid gameid, Guid genreid)
        {
            var result = await _mediator.Send(new AddGenreCommand
            {
                GameId = gameid,
                GenreId = genreid
            });

            if (result)
            {
                return Ok("Genre Added");
            }

            return BadRequest("Something went wrong");
        }


        [HttpPost]
        [Route("game/{gameid}/developer/{developerid}")]
        public async Task<IActionResult> AddDeveloperToGame(Guid gameid, Guid developerid)
        {
            var result = await _mediator.Send(new AddDeveloperCommand
            {
                GameId = gameid,
                DeveloperId = developerid
            });

            if (result)
            {
                return Ok("Developer Added");
            }

            return BadRequest("Something went wrong");
        }


        [HttpPost]
        [Route("game/{gameid}/platform/{platformid}")]
        public async Task<IActionResult> AddPlatformToGame(Guid gameid, Guid platformid)
        {
            var result = await _mediator.Send(new AddPlatformCommand
            {
                GameId = gameid,
                PlatformId = platformid
            });

            if (result)
            {
                return Ok("Platform Added");
            }

            return BadRequest("Something went wrong");
        }

        [HttpDelete]
        [Route("game/{gameid}/genre/{genreid}")]
        public async Task<IActionResult> RemoveGenreFromGame(Guid gameid, Guid genreid)
        {
            var result = await _mediator.Send(new RemoveGenreCommand
            {
                GameId = gameid,
                GenreId = genreid
            });

            if (result)
            {
                return Ok("Genre Removed");
            }

            return BadRequest("Something went wrong");
        }

        [HttpDelete]
        [Route("game/{gameid}/platform/{platformid}")]
        public async Task<IActionResult> RemovePlatformFromGame(Guid gameid, Guid platformid)
        {
            var result = await _mediator.Send(new RemovePlatformCommand
            {
                GameId = gameid,
                PlatformId = platformid
            });

            if (result)
            {
                return Ok("Platform Removed");
            }

            return BadRequest("Something went wrong");
        }

        [HttpDelete]
        [Route("game/{gameid}/developer/{developerid}")]
        public async Task<IActionResult> RemoveDeveloperFromgame(Guid gameid, Guid developerid)
        {
            var result = await _mediator.Send(new RemoveDeveloperCommand
            {
                GameId = gameid,
                DeveloperId = developerid
            });

            if (result)
            {
                return Ok("Developer Removed");
            }

            return BadRequest("Something went wrong");
        }
    }
}
