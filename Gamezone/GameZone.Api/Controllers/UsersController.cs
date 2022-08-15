using GameZone.Api.ViewModels;
using GameZone.Application.Users.Commands.AddFavoriteGame;
using GameZone.Application.Users.Commands.CreateUser;
using GameZone.Application.Users.Commands.DeleteUser;
using GameZone.Application.Users.Commands.RemoveFavoriteGame;
using GameZone.Application.Users.Queries.GetUserById;
using GameZone.Application.Users.Queries.GetUsersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var query = new GetUserByIdQuery { Id = Id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _mediator.Send(new GetUsersListQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlatform([FromBody] UserViewModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateUserCommand
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { Id = result }, result);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new DeleteUserCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        [Route("{userId}/games/{gameId}")]
        public async Task<IActionResult> AddGameToFavorite(Guid userId, Guid gameId)
        {
            var command = new AddFavoriteGameCommand
            {
                IdGame = gameId,
                IdUser = userId
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("{userId}/games/{gameId}")]
        public async Task<IActionResult> RemoveGameFromFavorite(Guid userId, Guid gameId)
        {
            var command = new RemoveFavoriteGameCommand
            {
                GameId = gameId,
                UserId = userId
            };

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
