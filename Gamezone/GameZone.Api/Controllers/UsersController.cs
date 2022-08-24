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
    [Route("api/[controller]")]
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
        [Route("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var query = new GetUserByIdQuery { Id = Id };
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
        [Route("{Id}")]
        public async Task<IActionResult> DeleteUser(Guid Id)
        {
            var command = new DeleteUserCommand { Id = Id };
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
