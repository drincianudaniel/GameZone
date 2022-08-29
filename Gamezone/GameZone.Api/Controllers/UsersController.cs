using AutoMapper;
using GameZone.Api.DTOs;
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
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper=mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<UserDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _mediator.Send(new GetUsersListQuery());
            var mappedResult = _mapper.Map<IEnumerable<UserDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserViewModel user)
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
            var mappedResult = _mapper.Map<UserDto>(result);

            return CreatedAtAction(nameof(GetById), new { Id = mappedResult.Id }, mappedResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new DeleteUserCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        [Route("{userid}/games/{gameid}")]
        public async Task<IActionResult> AddGameToFavorite(Guid userid, Guid gameid)
        {
            var command = new AddFavoriteGameCommand
            {
                IdGame = gameid,
                IdUser = userid
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("{userid}/games/{gameid}")]
        public async Task<IActionResult> RemoveGameFromFavorite(Guid userid, Guid gameid)
        {
            var command = new RemoveFavoriteGameCommand
            {
                GameId = gameid,
                UserId = userid
            };

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
